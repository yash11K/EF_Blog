using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFirst.models;

public class Post
{
    public int Id { get; set; }
    [MaxLength(255)]
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime CreatedAt { get; } = DateTime.Now;

    public int AuthorId { get; set; }
    
    [ForeignKey("AuthorId")] 
    public Author Author;
}