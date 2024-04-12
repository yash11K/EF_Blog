using EFirst.models;

namespace EFirst.repositories;

public interface ITagRepository
{
    public Task<Tag> CreateTag(Tag tag);

    public Task<bool> IsTag(string name);

    public Task<Tag?> FetchTagByName(string name);
}