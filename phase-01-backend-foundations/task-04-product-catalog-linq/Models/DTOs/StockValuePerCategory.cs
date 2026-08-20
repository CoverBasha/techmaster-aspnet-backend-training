using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_04_product_catalog_linq.Models.DTOs
{
    public class StockValuePerCategory
    {
        public string Category { get; set; } = "";
        public decimal StockValue { get; set; }
    }
}
