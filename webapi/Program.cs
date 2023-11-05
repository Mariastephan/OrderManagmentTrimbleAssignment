using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using orderManagement.webApi.DataAccess;
using orderManagement.webApi.DataContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(Options => Options.AddPolicy("AllowAnyOrigin", builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
}));
builder.Services.AddDbContext<OrderDetailsDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("OrderDetailsDBConnectionString")));

builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAnyOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
