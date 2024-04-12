using EFirst.database;
using EFirst.models;
using EFirst.Request;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFirst.repositories;

public class PostRepository : IPostRepository
{
    private readonly BlogDbContext _context;

    public PostRepository(BlogDbContext context) => _context = context;

    public async Task<IEnumerable<Post>> FetchAllPosts()
    {
        var posts = _context.Posts; 
        if (posts != null)
        { 
            return posts.AsEnumerable();
        }
        else
        {
            throw new Exception("No Posts Available");
        } 
    }

    public async Task<EntityEntry<Post>> SavePost(Post post)
    {
        var p = _context.Posts!.AddAsync(post).Result;
        await _context.SaveChangesAsync();
        return p; 
    }

    public async Task<Post?> FetchPost(int postId)
    {
        return _context.Posts?.Single(p => p.Id == postId);
    }
}
