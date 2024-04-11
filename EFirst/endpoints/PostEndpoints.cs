using EFirst.repositories;

namespace EFirst.endpoints;

public static class PostEndpoints
{

   public static void MapPostEndPoints(this WebApplication app)
   {
      app.MapGet("/post/all", (IPostRepository postRepository) => postRepository.FetchAllPosts().Result)
         .WithName("all_posts")
         .WithOpenApi(); 
   }
}