using Core.Abstractions;
using Core.DTOs;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Services;

public class EventService : IEventService
{
    private readonly IDbContext _context;
    public EventService(IDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Event>> GetAllEventsAsync()
    {
        return await _context.Events.Include(e => e.User).ToListAsync();
    }

    public async Task<Event> GetEventByIdAsync(Guid id)
    {
        return await _context.Events.Include(e => e.User).FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Event> CreateEventAsync(Guid currentUserId, EventDTO eventDto)
    {
        
        var @event = new Event
        {
            Name = eventDto.Name,
            ShortDescription = eventDto.ShortDescription,
            LongDescription = eventDto.LongDescription,
            Place = eventDto.Place,
            Date = eventDto.Date,
            ImageUrl = eventDto.ImageUrl,
            UserId = currentUserId
        };
        _context.Events.Add(@event);
        await _context.SaveChangesAsync();

        return @event;
    }

    public async Task UpdateEventAsync(Guid id, EventDTO eventDto)
    {
        var @event = await _context.Events.FindAsync(id);
        if (@event == null) return;

        @event.Name = eventDto.Name;
        @event.ShortDescription = eventDto.ShortDescription;
        @event.LongDescription = eventDto.LongDescription;
        @event.Place = eventDto.Place;
        @event.Date = eventDto.Date;
        @event.ImageUrl = eventDto.ImageUrl;

        _context.Events.Update(@event);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEventAsync(Guid id)
    {
        var @event = await _context.Events.FindAsync(id);
        if (@event == null) return;

        _context.Events.Remove(@event);
        await _context.SaveChangesAsync();
    }
}
