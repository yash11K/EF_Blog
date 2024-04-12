using EFirst.models;

namespace EFirst.repositories;

public interface IAuthorRepository
{
    public Task<Author> FetchAuthorFromName(string name);
}