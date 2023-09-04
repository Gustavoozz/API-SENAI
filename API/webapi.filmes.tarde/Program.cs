using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o serviço de controllers.
builder.Services.AddControllers();

// Adiciona serviço de autenticação JWT Bearer.
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

// Define os parâmetros de validação do Token
.AddJwtBearer("JwtBearer", options => 
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // Valida quem está solicitando 
        ValidateIssuer = true,

        // Valida quem está recebendo
        ValidateAudience = true,

        // Define se o tempo de expiração do token será validado
        ValidateLifetime = true,

        // Froma de criptografia e ainda validação da chave de autenticação
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Filmes.chave.autenticacao-webapi-dev")),

        // Valida o tempo de expiação do token
        ClockSkew = TimeSpan.FromMinutes(5),

        // De onde está vindo ( issuer )
        ValidIssuer = "webapi.filmes.tarde",

        // Para onde está indo ( audience )
        ValidAudience = "webapi.filmes.tarde"
    };
});

// Adiciona o gerador de Swagger.
builder.Services.AddSwaggerGen(options =>
{

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filmes",
        Description = "API para gerenciamento de filmes - Introdução a sprint 2 - Backend API.",
        Contact = new OpenApiContact
        {
            Name = "Gustavo Magalhães",
            Url = new Uri("https://github.com/Gustavoozz")
        },
    });

    // Configura o Swagger para usar o arquivo XML.
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    // Usando a autenticação no Swagger:
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
        new OpenApiSecurityScheme
           {
            Reference = new OpenApiReference
            {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
            }
        },
        new string[]{}
 }
    });
});

var app = builder.Build();

// Habilite o middleware para atender ao documento JSON gerado e à interface do usuário do Swagger.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Para atender à interface do usuário do Swagger na raiz do aplicativo.
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

// Usar autenticação 
app.UseAuthentication();

// Usar autorização
app.UseAuthorization();

//Mapear os controllers.
app.MapControllers();

app.Run();
