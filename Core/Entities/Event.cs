using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Event
{
    [Key] public Guid Id { get; set; }
}