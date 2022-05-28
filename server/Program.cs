using DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(o => {
    o.ClearProviders();
    o.AddConsole();
});

// Add services to the container.
builder.Services.AddCors(o => o.AddDefaultPolicy(p => p.AllowAnyOrigin()));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(
    new ConnectionManager(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<CitiesQueries>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
