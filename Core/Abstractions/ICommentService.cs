using Core.DTOs;
using Core.Entities;

namespace Core.Abstractions;

public interface ICommentService
{
    Task<IEnumerable<Comment>> GetCommentsByEventIdAsync(int eventId);
    Task<Comment> AddCommentAsync(CommentDTO commentDto);
}