using System.ComponentModel.DataAnnotations.Schema;

namespace EFirst.models;

public class Comments
{
    public int Id { get; set; }
    public string Body { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int PostId { get; set; }
    
    [ForeignKey("PostId")]
    public Post Post { get; set; } 
}