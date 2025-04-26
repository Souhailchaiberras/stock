using System.ComponentModel.DataAnnotations;

namespace API2.Dtos.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5,ErrorMessage ="the title must be 5 character ")]
        [MaxLength(100, ErrorMessage = "the title must be less than 100 character ")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(10, ErrorMessage = "the content must be 10 character ")]
        [MaxLength(500, ErrorMessage = "the content must be less than 500 character ")]
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int? StockId { get; set; }
       
    }
}
                                                 