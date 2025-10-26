using Microsoft.Extensions.Configuration;
using WebApplication52.Infrastructure.Configuration;
using WebApplication52.Presentation.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCORSPolicy();

builder.Services.DIContainerAdder(builder.Configuration);

var app = builder.Build();

app.UseBuilder(app.Environment);

app.MapControllers();

app.Run();
