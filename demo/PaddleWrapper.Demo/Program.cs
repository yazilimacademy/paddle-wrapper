using PaddleWrapper.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Paddle SDK configuration
builder.Services.AddPaddleServices(options =>
{
    options.ApiKey = "b9847347b603864b3ac8a5c3bd2b05a40b4fc591dc225e4fd2";
    options.UseSandbox = true; // or false for Production
    options.MaxRetryAttempts = 3;
    options.TimeoutSeconds = 30;
});

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();