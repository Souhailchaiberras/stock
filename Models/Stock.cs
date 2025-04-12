using System.ComponentModel.DataAnnotations.Schema;

namespace API2.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string Companyname { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18;2)")]
        public decimal Purchace { get; set; }
        [Column(TypeName = "decimal(18;2)")]
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
