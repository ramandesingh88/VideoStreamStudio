using VideoStream.InfraStructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("VideoStreamDatabase")
    ?? throw new InvalidOperationException("Connection string 'VideoStreamDatabase' not configured.");

    builder.Services.AddInfrastructure(connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHealthChecks("/health");

app.MapGet("/", () => Results.Ok(new
{
    service = "AI Video Streaming Platform API",
    version = "1.0.0",
    status = "Running"
}));

app.Run();


