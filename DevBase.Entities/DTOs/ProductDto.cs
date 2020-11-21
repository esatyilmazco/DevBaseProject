using System.Collections.Generic;
using System.Linq;
using DevBase.Entities.Tangible;

namespace DevBase.Entities.DTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }
}