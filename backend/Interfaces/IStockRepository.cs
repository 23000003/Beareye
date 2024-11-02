using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Stock;
using backend.Helpers;
using backend.Models;

/**
    Interfaces allows abstractions
    Plugin this code to other places

    This is used in Repository
**/
namespace backend.Interfaces
{
    public interface IStockRepository
    {
        // Returns lists of stocks
        Task <List<Stock>> GetAllAsync(QueryObject query);
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stock);
        Task<Stock?> DeleteAsync(int id);
        Task<bool> StockExists(int id);
        Task<Stock?> GetBySymbolAsync(string symbol);
    }
}