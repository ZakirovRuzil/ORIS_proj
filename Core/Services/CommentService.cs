using Core.Abstractions;
using Core.DTOs;
using Core.Entities;

namespace Core.Services;

public class CommentService : ICommentService
{
    public Task<IEnumerable<Comment>> GetCommentsByEventIdAsync(int eventId)
    {
        throw new NotImplementedException();
    }

    public Task<Comment> AddCommentAsync(CommentDTO commentDto)
    {
        throw new NotImplementedException();
    }
}