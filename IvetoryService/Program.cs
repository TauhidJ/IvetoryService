using InventoryService.Aggregate;
using InventoryService.Application.InventoryQueries;
using InventoryService.Configurations;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IInventoryRepository, InventoryRepository>();

builder.Services.AddTransient<IInventoryQueries, InventoryQueries>();

builder.Services.AddDbContext<ApplicationDbContext>((s, p) =>
{
    p.UseSqlServer(builder.Configuration.GetConnectionString("ConStr"));

});

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

app.UseAuthorization();

app.MapControllers();

app.Run();
