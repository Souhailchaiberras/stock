using API2.Dtos.Comment;
using API2.Models; 
namespace API2.Interface
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment?> createAsync(Comment commentmodel);
        Task<Comment?> updateAsync(int id, Comment commentmodel);

    }
}
