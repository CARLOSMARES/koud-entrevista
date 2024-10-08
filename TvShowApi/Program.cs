using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TvShowContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var MyAllowSpecioficOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecioficOrigins, policy =>
    {
        policy.WithOrigins("*")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
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
app.UseCors(MyAllowSpecioficOrigins);

app.MapGet("/", () => "Hola Mundo");

app.MapGet("/api/v1/All", async (TvShowContext context) =>
{
    return await context.TvShows.ToListAsync();
});

app.MapGet("/api/v1/{id}", async (int id, TvShowContext context) =>
{
    return await context.TvShows.FirstOrDefaultAsync(x => x.Id == id);
});

app.MapGet("/api/v1/search/{name}", async (string name, TvShowContext context) =>
{
    return await context.TvShows.FirstOrDefaultAsync(x => x.Name == name);
});

app.MapPost("/api/v1/New", (TvShow tvShow, TvShowContext context) =>
{
    context.TvShows.Add(tvShow);
    context.SaveChanges();
    return tvShow;
});

app.MapDelete("/api/v1/{id}", (int id, TvShowContext context) =>
{
    TvShow entidad = context.TvShows.First(x => x.Id == id);
    context.Remove(entidad);
    context.SaveChanges();
    return entidad;
});

app.MapPut("/api/v1/", (TvShow tvShow, TvShowContext context) =>
{
    context.Update(tvShow);
    context.SaveChanges();
    return tvShow;
    
});

app.Run();
