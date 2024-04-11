using EFirst.database;
using EFirst.models;
using Microsoft.EntityFrameworkCore;

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
}
