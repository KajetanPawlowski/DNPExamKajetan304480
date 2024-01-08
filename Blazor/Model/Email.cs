namespace Blazor.Data;

public class Email
{
    public string SenderName { get; set; }
    public string ReceiverName { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime Timestamp { get; set; } 
}