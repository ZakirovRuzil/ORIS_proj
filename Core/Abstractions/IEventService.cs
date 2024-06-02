using Core.DTOs;
using Core.Entities;

namespace Core.Abstractions;

public interface IEventService
{
    Task<IEnumerable<Event>> GetAllEventsAsync();
    Task<Event> GetEventByIdAsync(Guid id);
    Task<Event> CreateEventAsync(Guid currentUserId, EventDTO eventDto);
    Task UpdateEventAsync(Guid id, EventDTO eventDto);
    Task DeleteEventAsync(Guid id);
}