using API2.Dtos.Stock;
using API2.Models;
using Microsoft.AspNetCore.Mvc;


namespace API2.Interface
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock?> createAsync(Stock stockmodel);
        Task<Stock?> updateAsync(int id , UpdateRequestDTO stockDto);
        Task<Stock?> deleteAsync(int id);

    }
}
