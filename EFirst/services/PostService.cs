using EFirst.mapper;
using EFirst.models;
using EFirst.repositories;
using EFirst.Request;

namespace EFirst.services;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly ITagRepository _tagRepository;
    private readonly IAuthorRepository _authorRepository;

    public PostService(IPostRepository postRepository, ITagRepository tagRepository, IAuthorRepository authorRepository)
    {
        _postRepository = postRepository;
        _tagRepository = tagRepository;
        _authorRepository = authorRepository;
    }

    public async Task<IEnumerable<Post>> FetchAllPosts()
    {
        return await _postRepository.FetchAllPosts();
    }

    public async Task<Post> NewPostBuilder(PostRequest postRequest)
    {
        var tags = new List<Tag>(); 
        if (postRequest.TagNames != null)
        {
           foreach (var tagName in postRequest.TagNames)
           {
               if (!await _tagRepository.IsTag(tagName))
               {
                   var tagRequest = new TagRequest
                   {
                       Name = tagName
                   };
                   tags.Add(await _tagRepository.CreateTag(ApiContractToEntity.ToNewTag(tagRequest)));
               }
               else
               {
                   var tag = await _tagRepository.FetchTagByName(tagName);
                   if (tag != null)
                   {
                       tags.Add(tag);
                   }
               }
           }
        }

        var author = await _authorRepository.FetchAuthorFromName("yash");
        var post = new Post
        {
            Title = postRequest.Title,
            Body = postRequest.Body,
            Tags = tags,
            Author = author,
            AuthorId = author.Id,
            CreatedAt = DateTime.Now
        };
        return post; 
    }

    public async Task<Post?> FetchPost(int postId)
    {
        return await _postRepository.FetchPost(postId);
    }
}