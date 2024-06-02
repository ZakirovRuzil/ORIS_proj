using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Core.Abstractions;
using Core.DTOs;
using Eventify.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eventify.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEvents()
    {
        var events = await _eventService.GetAllEventsAsync();
        return Ok(events);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateEvent([FromBody] EventDTO eventDto)
    {
        var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier);
         if (!Guid.TryParse(currentUserId?.Value, out var userId))
            throw new ValidationException("Текущий пользователь не найден");
        var createdEvent = await _eventService.CreateEventAsync(userId, eventDto);
        return CreatedAtAction(nameof(GetEventById), new { id = createdEvent.Id }, createdEvent);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEventById(Guid id)
    {
        var @event = await _eventService.GetEventByIdAsync(id);
        if (@event == null)
        {
            return NotFound();
        }

        return Ok(@event);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEvent(Guid id, [FromBody] EventDTO eventDto)
    {
        await _eventService.UpdateEventAsync(id, eventDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(Guid id)
    {
        await _eventService.DeleteEventAsync(id);
        return NoContent();
    }
}