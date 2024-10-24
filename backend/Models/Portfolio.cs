using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

/**
    Join Table
**/
namespace backend.Models
{
    [Table("Portfolios")]
    public class Portfolio
    {
        public string AppUserId { get; set; }
        public int StockId { get; set; }
        /**Navigation Property below, 
            ( At the top is Optional if u want it to be shown in the DB or other use cases )
        **/
        public AppUser AppUser { get; set; }
        public Stock Stock { get; set; }
    }

}