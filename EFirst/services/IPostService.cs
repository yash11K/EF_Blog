using EFirst.models;
using EFirst.repositories;
using EFirst.Request;

namespace EFirst.services;

public interface IPostService
{
    public Task<IEnumerable<Post>> FetchAllPosts();

    public Task<Post> NewPostBuilder(PostRequest postRequest);

    public Task<Post?> FetchPost(int postId);
}