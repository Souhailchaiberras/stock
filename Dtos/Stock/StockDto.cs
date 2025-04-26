using API2.Models;
using API2.Dtos.Comment;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API2.Dtos.Stock
{
    public class StockDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "the symbol must not surpase 10 character ")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(10, ErrorMessage = "the company name must not surpase 100 character ")]
        public string Companyname { get; set; } = string.Empty;
        [Required]
        [Range(1, 1000000)]
        public decimal Purchace { get; set; }
        [Required]
        [Range(0.1, 100)]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "the industry name must not surpase 10 character ")]
        public string Industry { get; set; } = string.Empty;
        [Required]
        [Range(1, 10000000000000000000)]
        public long MarketCap { get; set; }
        public List<CommentDto> Comment { get; set; }
    }
}
