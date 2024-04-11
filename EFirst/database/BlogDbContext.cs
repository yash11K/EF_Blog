using System.Configuration;
using EFirst.models;
using Microsoft.EntityFrameworkCore;

namespace EFirst.database;

public class BlogDbContext : DbContext {
    public DbSet<Post>? Posts { get; set; }
    public DbSet<Author>? Authors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseMySQL( "server=localhost;port=3306;database=blog_c;user=blogAdmin;password=0000;"); 
    }
}