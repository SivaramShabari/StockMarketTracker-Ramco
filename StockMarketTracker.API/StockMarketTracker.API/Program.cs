using StockMarketTracker.API.Configurations;
using StockMarketTracker.Business;
using StockMarketTracker.Business.Contracts;
using StockMarketTracker.Repository;
using StockMarketTracker.Repository.Contracts;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
});  

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));

builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IStockManager, StockManager>();

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", p =>
{
    p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors("MyPolicy");

app.Run();
