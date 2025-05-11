using mTemp_API.Adapters.Middleware;
using mTemp_API.Domain.Repositories;
using mTemp_API.Domain.Repositories.Implementations;
using mTemp_API.Domain.Services;
using mTemp_API.Domain.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IPatientsRepository, InMemoryPatientsRepository>();
builder.Services.AddSingleton<ITemperatureMeasurementsRepository, InMemoryTemperatureMeasurementsRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<ITemperatureMeasurementService, TemperatureMeasurementService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy
            .SetIsOriginAllowed(origin =>
                new Uri(origin).Host.Equals("localhost", StringComparison.OrdinalIgnoreCase))
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowLocalhost");
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Register the custom exception handling middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();

// TODO
// - readme
// - unit tests
// - documentation of methods
// - swagger annotations
