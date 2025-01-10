using Microsoft.OpenApi.Models;
using PaddleWrapper.Core.Extensions;
using System.Reflection;
using System.Text.Json;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers()
    .AddNewtonsoftJson(); // Add Newtonsoft.Json support

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Paddle API Wrapper Demo",
        Version = "v1",
        Description = "A demo application showcasing the Paddle API wrapper functionality",
        Contact = new OpenApiContact
        {
            Name = "Your Name",
            Email = "your.email@example.com"
        }
    });

    // Include XML comments
    string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// Configure Paddle API
builder.Services.AddPaddleServices(options =>
{
    builder.Configuration.GetSection("Paddle").Bind(options);
});

// Add logging
builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.AddDebug();
});

WebApplication app = builder.Build();

// Global error handling
app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";

        var response = new
        {
            success = false,
            response = (string)null,
            error = ex.Message
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
});

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Paddle API Wrapper Demo v1");
        c.RoutePrefix = string.Empty; // Serve Swagger UI at the root
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();