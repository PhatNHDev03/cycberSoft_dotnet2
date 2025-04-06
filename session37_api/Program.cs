using Microsoft.EntityFrameworkCore;
using session37_api.Data;
var builder = WebApplication.CreateBuilder(args);


//add dbcontext
builder.Services.AddDbContext<AppDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// dang ki api va nhung controller khac cho webApi
builder.Services.AddControllers();
// dang ki swagger
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
// them middleware Mapcontroller de dieu huong Api toi controller phu hop bat buoc
app.MapControllers();




app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
