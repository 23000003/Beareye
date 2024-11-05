using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Dtos.Stock;
using backend.Helpers;
using backend.Interfaces;
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
        private readonly IStockRepository stockRepo;
        public StockController(ApplicationDBContext context, IStockRepository stockRepo)
        {
            this.context = context;
            this.stockRepo = stockRepo;
        }

        // **** This Returns the query parameter data of stock or all stocks *** ///
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var stocks = await stockRepo.GetAllAsync(query);

            var stockDto = stocks.Select(s => s.ToStockDto()).ToList();

            return Ok(stockDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var stock = await stockRepo.GetByIdAsync(id);

            if(stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var stockModel = stockDto.ToStockFromCreateDTO();
            await stockRepo.CreateAsync(stockModel);
            
            return CreatedAtAction(nameof(GetById), 
                new { id = stockModel.Id }, stockModel.ToStockDto()
            );
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var stockModel = await stockRepo.UpdateAsync(id, updateDto);

            if(stockModel == null){
                return NotFound();
            }

            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var stockModel = await stockRepo.DeleteAsync(id);

            if(stockModel == null){
                return NotFound();
            }

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