using EFirst.database;
using EFirst.models;

namespace EFirst.repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly BlogDbContext _context;

    public AuthorRepository(BlogDbContext context)
    {
        _context = context;
    }

    public async Task<Author> FetchAuthorFromName(string name)
    {
        return  _context.Authors?.Single(a => a.Name == name) ?? throw new InvalidOperationException();
    }
}