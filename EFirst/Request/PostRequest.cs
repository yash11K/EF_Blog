namespace EFirst.Request;

public class PostRequest
{
    public required string Title { get; set; }
    public required string Body { get; set; }
    public List<string>? TagNames { get; set; }
    
}