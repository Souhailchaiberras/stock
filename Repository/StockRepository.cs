using API2.Data;
using API2.Dtos.Stock;
using API2.Interface;
using API2.Models;
using Microsoft.EntityFrameworkCore;
namespace API2.Repository
{
    public class StockRepository: IStockRepository
    {
        private readonly ApplicationDBCContext _context;
        public StockRepository(ApplicationDBCContext context)
        {
            _context = context;
        }

        public async Task<Stock?> createAsync(Stock stockmodel)
        {
            await _context.Stock.AddAsync(stockmodel);
            await _context.SaveChangesAsync();
            return stockmodel;
        }

        public async  Task<Stock?> deleteAsync(int id)
        {
         var  exist = await _context.Stock.Include(s=>s.Comments).FirstOrDefaultAsync(Stock => Stock.Id == id);
            if (exist == null)
            {
                return null;
            }
            _context.Stock.Remove(exist);
            await _context.SaveChangesAsync();
            return exist;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stock.Include(s => s.Comments).ToListAsync();
        }
        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stock.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> stockexict(int id)
        {
            return await _context.Stock.AnyAsync(s => s.Id == id);
        }

        public async Task<Stock?> updateAsync(int id, UpdateRequestDTO stockDto)
        {
            var exist  = await _context.Stock.FindAsync(id);
            if (exist  == null)
            {
                return null;
            }
            exist.Symbol = stockDto.Symbol;
            exist.Companyname = stockDto.Companyname;
            exist.Purchace = stockDto.Purchace;
            exist.LastDiv = stockDto.LastDiv;
            exist.Industry = stockDto.Industry;
            exist.MarketCap = stockDto.MarketCap;
            await _context.SaveChangesAsync();
            return exist;
        }
    }
}
