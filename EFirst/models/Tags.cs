namespace EFirst.models;

public class Tags
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; }
    
    public List<Post>? Posts { get; set; }
}