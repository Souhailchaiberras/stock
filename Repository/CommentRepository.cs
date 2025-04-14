using API2.Data;
using API2.Dtos.Comment;
using API2.Interface;
using API2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;


namespace API2.Repository
{
    public class CommentRepository:ICommentRepository
    {
        private readonly ApplicationDBCContext _context;
        public CommentRepository(ApplicationDBCContext context)
        {
            _context = context;
        }
       public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comment.ToListAsync();
        }
        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comment.FirstOrDefaultAsync(c => c.Id==id);
        }
        public async Task<Comment?> createAsync(Comment commentmodel)
        {
      
            
            await _context.Comment.AddAsync(commentmodel);
            await _context.SaveChangesAsync();
            return commentmodel;
        }

        public async Task<Comment?> updateAsync(int id, Comment commentmodel)
        {
            var comment = await _context.Comment.FindAsync(id);
           
            comment.Title = commentmodel.Title;
            comment.Content = commentmodel.Content;
            await _context.SaveChangesAsync();
            return comment;



        }
    }
}
