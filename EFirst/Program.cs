using EFirst.database;
using EFirst.models;

Console.WriteLine("Hello World");

// var builder = WebApplication.CreateBuilder(args);
//
// // Add services to the container.
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
//
// var app = builder.Build();
//
// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
//
// app.UseHttpsRedirection();
//
// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };
//
// app.MapGet("/weatherforecast", () =>
//     {
//         var forecast = Enumerable.Range(1, 5).Select(index =>
//                 new WeatherForecast
//                 (
//                     DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//                     Random.Shared.Next(-20, 55),
//                     summaries[Random.Shared.Next(summaries.Length)]
//                 ))
//             .ToArray();
//         return forecast;
//     })
//     .WithName("GetWeatherForecast")
//     .WithOpenApi();
//
// app.Run();
//
// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BlogDbContext>();
builder.Build();
var context = new BlogDbContext();
var transaction = context.Database.BeginTransaction();
try
{
    context.Add(
        new Author
        {
            Id = 1, Name = "yash"
        }
    );
    context.SaveChanges();

    context.Add(new Post
    {
        Id = 1, Title = "First Ever Blog", AuthorId = 1, Body = "Loreal Epsum Loreal Epsum Loreal Epsum Loreal Epsum"
    });
    context.SaveChanges();
    transaction.Commit();
}   
catch (Exception){
    Console.WriteLine("wow what an error");
}
finally
{
   context.Dispose();
   transaction.Dispose();
}