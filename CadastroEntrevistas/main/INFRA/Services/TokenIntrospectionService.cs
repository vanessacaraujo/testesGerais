using System.Security.Claims;
using System.Text.Json;

namespace CadastroEntrevista.INFRA.Services
{
    public class TokenIntrospectionService
    {
        private readonly HttpClient _httpClient;

        public TokenIntrospectionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ClaimsPrincipal?> ValidateTokenAsync(string token)
        {
            var content = new FormUrlEncodedContent(new[]
            {new KeyValuePair<string, string>("token", token)});

            var response = await _httpClient.PostAsync("http://localhost:5001/introspect", content);
            var json = await response.Content.ReadAsStringAsync();

            var data = JsonDocument.Parse(json).RootElement;

            if (!data.GetProperty("ativo").GetBoolean())
                return null;

            var claims = new List<Claim>
            {
                new Claim("nome", data.GetProperty("nome").GetString() ?? ""),
                new Claim("email", data.GetProperty("email").GetString() ?? ""),
                new Claim("escopo", data.GetProperty("escopo").GetString() ?? "")
            };

            var identity = new ClaimsIdentity(claims, "Introspection");
            return new ClaimsPrincipal(identity);
        }
    }
}
