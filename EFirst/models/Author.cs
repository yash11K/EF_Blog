using System.ComponentModel.DataAnnotations.Schema;

namespace EFirst.models;

public class Author
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Post>? Posts { get; set;}
}