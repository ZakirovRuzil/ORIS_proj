using Core.Abstractions;
using Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Eventify.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet("event/{eventId}")]
    public async Task<IActionResult> GetCommentsByEventId(int eventId)
    {
        var comments = await _commentService.GetCommentsByEventIdAsync(eventId);
        return Ok(comments);
    }

    [HttpPost]
    public async Task<IActionResult> AddComment([FromBody] CommentDTO commentDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdComment = await _commentService.AddCommentAsync(commentDto);
        return CreatedAtAction(nameof(GetCommentsByEventId), new { eventId = createdComment.EventId }, createdComment);
    }
}