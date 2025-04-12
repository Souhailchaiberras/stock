 using API2.Dtos.Stock;
using API2.Models;

namespace API2.Mappers
{
    public static class StockMappers
    {
        
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                Companyname = stockModel.Companyname,
                Purchace = stockModel.Purchace,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap
            };
        }

        
        public static Stock ToStockFromCreateDto(this CreateStockRequest stockDto)
        {
            return new Stock
            {

                Symbol = stockDto.Symbol,
                Companyname = stockDto.Companyname,
                Purchace = stockDto.Purchace,
                LastDiv = stockDto.LastDiv,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap
            };
        }
        
    }
}
