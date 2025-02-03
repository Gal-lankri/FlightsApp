using FlightsApp.Data;
using FlightsApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Register Database Connection
builder.Services.AddSingleton<DatabaseConnection>();

// Add services to the container.
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IFlightService, FlightService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();


    var dbConnection = app.Services.GetRequiredService<DatabaseConnection>();
    if (dbConnection.TestConnection())
    {
        Console.WriteLine("Database connection successful!");
    }
    else
    {
        Console.WriteLine("Database connection failed");
    }

app.Run();
