using EFirst.models;

namespace EFirst.repositories;

public interface IPostRepository
{
    public Task<IEnumerable<Post>> FetchAllPosts(); 
}