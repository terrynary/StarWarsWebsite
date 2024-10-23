using Microsoft.OpenApi.Models;
using StarWarsWebsite.Server.Context;
using StarWarsWebsite.Server.Data.Interfaces;
using StarWarsWebsite.Server.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using StarWarsWebsite.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "GoEngineering SWAPI",
        Description = "Minimal CRUD API to handle StarShips from Star Wars."
    });
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .Build();
    });
});

builder.Services.AddDbContext<StarWarsContext>();

builder.Services.AddScoped<IStarShipRepo, StarShipRepo>();

var app = builder.Build();
app.UseCors();
var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<StarWarsContext>();
DataSeeding.Initialize(context);

app.MapGet("/starShips",(IStarShipRepo repo) => 
{
    var result = repo.GetStarShips();
    if(result.Count < 1)
    {
        return Results.NotFound("Star Ships could not be found");
    }
    return Results.Ok(result);
});

app.MapGet("/luckyStarShip", (IStarShipRepo repo) =>
{
    var result = repo.GetLuckyStarShip();
    if(result == new StarShip())
    {
        return Results.NotFound("Lucky Star Ship is not so lucky");
    }
    return Results.Ok(result);
});

app.MapGet("/starShip/{starShipId:int}", (IStarShipRepo repo, [FromRoute] int starShipId) =>
{
    var result = repo.GetStarShip(starShipId);
    if(result.Id == 0)
    {
        return Results.NotFound("Star Ship could not be found");
    }
    return Results.Ok(result);
});

app.MapPost("/createStarShip", (IStarShipRepo repo, [FromBody] StarShip starShip) =>
{
    var result = repo.CreateStarShip(starShip);
    if( result.Id == 0)
    {
        return Results.Problem("Star Ship could not be created"); 
    }
    return Results.Ok("Star Ship was created");
});

app.MapPut("/updateStarShip/{starShipId:int}", (IStarShipRepo repo, [FromRoute] int starShipId, [FromBody] StarShip starShip) =>
{
    var result = repo.UpdateStarShip(starShip);
    if(result == false)
    {
        return Results.Problem("Star Ship was not updated");
    }
    return Results.Ok("Star Ship was updated");
});

app.MapDelete("/deleteStarShip/{starShipId:int}", (IStarShipRepo repo, [FromRoute] int starShipId) =>
{
    var result = repo.DeleteStarShip(starShipId);
    if(result == false)
    {
        return Results.Problem("Star Ship was not deleted");
    }
    return Results.Ok("Star Ship was deleted");
});

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapFallbackToFile("/index.html");

app.Run();
