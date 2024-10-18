using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Comment;

/**********************************************
    Data Transfer Object
    This is just a copy of the Model
    Trims a Specific Data/Column
    Its like Filtering a Data that you dont want to get From A Request
    This is a Instance Class that will be used in the Mapper
    
***********************************************/
namespace backend.Dtos.Stock
{
    public class StockDto
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName{ get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
        public List<CommentDto> Comments { get; set; }
        
    }
}