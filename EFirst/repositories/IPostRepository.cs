using EFirst.models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFirst.repositories;

public interface IPostRepository
{
    public Task<IEnumerable<Post>> FetchAllPosts();
    
    public Task<EntityEntry<Post>> SavePost(Post post);

    public Task<Post?> FetchPost(int postId);
}