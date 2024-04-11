using EFirst.database;
using EFirst.endpoints;
using EFirst.repositories;

Console.WriteLine("Hello World");

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BlogDbContext>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapPostEndPoints();
app.Run();

