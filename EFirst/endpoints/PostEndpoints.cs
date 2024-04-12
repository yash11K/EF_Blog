using EFirst.models;
using EFirst.repositories;
using EFirst.Request;
using EFirst.services;

namespace EFirst.endpoints;

public static class PostEndpoints
{
   public static void MapPostEndPoints(this WebApplication app)
   {
      app.MapGet("/post/all", (IPostRepository postRepository) => postRepository.FetchAllPosts().Result)
         .WithName("all_posts")
         .WithOpenApi();

      app.MapPost("/post/new", CreateNewPost)
         .WithName("new_post")
         .WithOpenApi();

      app.MapPost("/post/{postId}", GetSinglePost)
         .WithName("post_single")
         .WithOpenApi();
   }

   private static void GetAllPosts(IPostRepository postRepository)
   {
      
   }

   private static Post CreateNewPost(PostRequest postRequest,IPostService postService, IPostRepository postRepository)
   {
      var post = postService.NewPostBuilder(postRequest).Result;
      return postRepository.SavePost(post).Result.Entity;
   }

   private static Post GetSinglePost(int postId, IPostService postService)
   {
      var post = postService.FetchPost(postId);
      if (post.IsCompletedSuccessfully)
      {
         return post.Result!; 
      }
      return new Post();
   }
}