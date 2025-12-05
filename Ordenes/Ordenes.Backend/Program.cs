using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Ordenes.Backend.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=LocalConnection"));

var app = builder.Build();
app.UseCors(x => x
.AllowAnyMethod()
.AllowAnyHeader()
.SetIsOriginAllowed(origin =>true)
.AllowCredentials());

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //app.UseSwaggerUI();
    /*app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v3.json", "v1");
    });*/
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();