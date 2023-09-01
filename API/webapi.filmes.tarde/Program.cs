using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o servi�o de controllers.
builder.Services.AddControllers();

// Adiciona servi�o de autentica��o JWT Bearer.
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

// Define os par�metros de valida��o do Token
.AddJwtBearer(options => { });

// Adiciona o gerador de Swagger.
builder.Services.AddSwaggerGen(options =>
{

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filmes",
        Description = "API para gerenciamento de filmes - Introdu��o a sprint 2 - Backend API.",
        Contact = new OpenApiContact
        {
            Name = "Gustavo Magalh�es",
            Url = new Uri("https://github.com/Gustavoozz")
        },
    });

    // Configura o Swagger para usar o arquivo XML.
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Habilite o middleware para atender ao documento JSON gerado e � interface do usu�rio do Swagger.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Para atender � interface do usu�rio do Swagger na raiz do aplicativo.
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

//Mapear os controllers.
app.MapControllers();

app.Run();
