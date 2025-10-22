using CadastroEntrevista.INFRA.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;

namespace CadastroEntrevista.INFRA.Handlers
{
    public class TokenFakeAuthHandler :
        AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly TokenIntrospectionService _introspection;

        public TokenFakeAuthHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            TokenIntrospectionService introspection)
            : base(options, logger, encoder)
        {
            _introspection = introspection;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authHeader = Request.Headers["Authorization"].ToString();

            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
                return AuthenticateResult.Fail("Token ausente ou inválido.");

            var token = authHeader.Substring("Bearer ".Length).Trim();

            var principal = await _introspection.ValidateTokenAsync(token);

            if (principal == null)
                return AuthenticateResult.Fail("Token inválido.");

            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
    }
}
