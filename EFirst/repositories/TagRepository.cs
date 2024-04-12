using EFirst.database;
using EFirst.models;

namespace EFirst.repositories;

public class TagRepository : ITagRepository
{
    private readonly BlogDbContext _context;

    public TagRepository(BlogDbContext context) => _context = context;

    public async Task<Tag> CreateTag(Tag tag)
    {
        var tagEntry = await _context.AddAsync(tag);
        await _context.SaveChangesAsync();
        return tagEntry.Entity; 
    }

    public async Task<bool> IsTag(string name)
    {
        return (_context.Tags?.SingleOrDefault(t=> t.Name == name) != null);
    }

    public async Task<Tag?> FetchTagByName(string name)
    {
        return (_context.Tags?.SingleOrDefault(t => t.Name == name));
    }
}