using CadastroEntrevista.INFRA.Extensions;
using CadastroEntrevista.INFRA.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders(); // Clear default providers if needed
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigurarSwagger();
builder.Services.ConfigurarToken();
builder.Services.ConfigurarRefit();
builder.Services.AddAuthorization();
builder.Services.ConfigurarAutoMapper();
builder.Services.RegistrarServicos();
builder.Services.ConexaoDynamoDB(builder.Configuration);
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.Run();
