using API2.Data;
using API2.Dtos.Comment;
using API2.Interface;
using API2.Mappers;
using API2.Models;
using Microsoft.AspNetCore.Mvc;


namespace API2.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentControllercs : ControllerBase
    {
        private readonly ApplicationDBCContext _context;
        private readonly ICommentRepository _commentrepo;
        private readonly IStockRepository _stockrepo;
        public CommentControllercs(ApplicationDBCContext context,ICommentRepository commentRepository,IStockRepository stockrepo)
        {
            _context = context;
            _commentrepo = commentRepository;
            _stockrepo = stockrepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var comments = await _commentrepo.GetAllAsync();
            var commentDto = comments.Select(c => c.tocommentDto());
            if (commentDto == null )
            {
                return NotFound("No comments found.");
            }

            return Ok(commentDto);
        }
        
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id )
        {
            var comment= await _commentrepo.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound("Comment not found.");
            }
            return Ok(comment.tocommentDto());
        }
        [HttpPost("{stockId}")]
        public async Task<IActionResult> Create([FromRoute]int stockId, [FromBody] CreateComment commentmodel)
        {
            if (!await _stockrepo.stockexict(stockId))
            {
                return BadRequest("Invalid comment data.");
            }
            var comment = commentmodel.tocreatecomment(stockId);
            
               await _commentrepo.createAsync(comment);
            return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment.tocommentDto());

        }
        [HttpPut("id/{id}")]
        public async Task<IActionResult> update([FromRoute] int id,[FromBody] UpdateCommentDto commentmodel) {
            var comment = await _commentrepo.updateAsync(id,commentmodel.toUpdatcomment());
            if (comment == null) { 
            return BadRequest("Comment not found.");
            }
            
            return Ok(comment.tocommentDto());
        }
        [HttpDelete]
        [Route("id/{id}")]
        public async Task<IActionResult> delete([FromRoute] int id)
        {
            var comment = await _context.Comment.FindAsync(id);
            if (comment == null)
            {
                return NotFound("Comment not found.");
            }
            _context.Comment.Remove(comment);   
            _context.SaveChanges();
            return NoContent();
        }

    }
}
