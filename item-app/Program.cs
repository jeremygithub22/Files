using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
var app = builder.Build();

// Serve index.html
app.UseDefaultFiles();
app.UseStaticFiles();


app.MapControllers();
app.Run();