using API2.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace API2.Dtos.Stock
{
    public class StockDto
    {
       
        public int Id { get; set; }

        public string Symbol { get; set; } = string.Empty;
        public string Companyname { get; set; } = string.Empty;

       
        public decimal Purchace { get; set; }
        
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
        

    }
}
