using API2.Models;

namespace API2.Interface
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
    }
}
