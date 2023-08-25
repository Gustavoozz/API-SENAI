using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o serviço de controllers.
builder.Services.AddControllers();

// Adiciona o gerador de Swagger.
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
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

//Mapear os controllers.
app.MapControllers();

app.Run();
