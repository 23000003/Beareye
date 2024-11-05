using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDBContext context;
        public PortfolioRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public async Task<Portfolio> CreateAsync(Portfolio portfolio)
        {
            await context.Portfolios.AddAsync(portfolio);
            await context.SaveChangesAsync();
            return portfolio;
        }

        public async Task<Portfolio> DeletePortfolio(AppUser appUser, string symbol)
        {
            var portfolioModel = await context.Portfolios.FirstOrDefaultAsync(
                    x => x.AppUserId == appUser.Id && x.Stock.Symbol.ToLower() == symbol.ToLower()
            );

            if(portfolioModel == null){
                return null;
            }

            context.Portfolios.Remove(portfolioModel);

            await context.SaveChangesAsync();

            return portfolioModel;
        }

        public async Task<List<Stock>> GetUserPortfolio(AppUser user)
        {
            return await context.Portfolios.Where(u => u.AppUserId == user.Id)
                .Select(stock => new Stock
                {
                    Id = stock.StockId,
                    Symbol = stock.Stock.Symbol,
                    CompanyName = stock.Stock.CompanyName,
                    Purchase = stock.Stock.Purchase,
                    LastDiv = stock.Stock.LastDiv,
                    Industry = stock.Stock.Industry,
                    MarketCap = stock.Stock.MarketCap
                }).ToListAsync();
        }
    }
}