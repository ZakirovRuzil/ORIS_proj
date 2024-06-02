namespace Core.DTOs;

public class EventDTO
{
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }
    public string Place { get; set; }
    public DateTime Date { get; set; }
    public string ImageUrl { get; set; }
}