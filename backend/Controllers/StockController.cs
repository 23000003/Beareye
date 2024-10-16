using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Dtos.Stock;
using backend.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase // put this first
    {
        private readonly ApplicationDBContext context;

        public StockController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet]     // Task<IActionResult>  is a Return type
        public async Task<IActionResult> GetAll()
        {
            var stocks = await context.Stock
                .ToListAsync();

            var stockDto = stocks.Select(s => s.ToStockDto());

            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await context.Stock.FindAsync(id);

            if(stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto.ToStockFromCreateDTO();
            await context.Stock.AddAsync(stockModel);
            await context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetById), 
                new { id = stockModel.Id }, stockModel.ToStockDto()
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            var stockModel = await context.Stock.FirstOrDefaultAsync(x => x.Id == id);

            if(stockModel == null){
                return NotFound();
            }

            context.Entry(stockModel).CurrentValues.SetValues(updateDto);

            // stockModel.Symbol = updateDto.Symbol;
            // stockModel.CompanyName = updateDto.CompanyName;
            // stockModel.Purchase = updateDto.Purchase;
            // stockModel.LastDiv = updateDto.LastDiv;
            // stockModel.Industry = updateDto.Industry;
            // stockModel.MarketCap = updateDto.MarketCap;

            await context.SaveChangesAsync();

            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await context.Stock.FirstOrDefaultAsync(x => x.Id == id);

            if(stockModel == null){
                return NotFound();
            }

            context.Stock.Remove(stockModel);

            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}

// {
//   "symbol": "BTC",
//   "companyName": "BITCOIN",
//   "purchase": 232,
//   "lastDiv": 2.1,
//   "industry": "BitcoinDotCom",
//   "marketCap": 2325312312
// }