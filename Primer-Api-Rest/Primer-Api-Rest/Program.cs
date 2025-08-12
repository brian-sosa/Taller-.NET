using Primer_Api_Rest.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();
builder.Services.AddSingleton<HomeController>();
builder.Services.AddMvc().AddControllersAsServices();





// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Primer-Api-Rest", Version = "v1" });
    // Si más adelante usas tipos especiales:
    // c.CustomSchemaIds(t => t.FullName);
    // c.MapType<DateOnly>(() => new OpenApiSchema { Type = "string", Format = "date" });
    // c.MapType<TimeOnly>(() => new OpenApiSchema { Type = "string", Format = "time" });
});

var app = builder.Build();

// Swagger también en Development (como ya tenías)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Primer-Api-Rest v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

