using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CategoryWithProductsDto : IDto
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public decimal UnitPrice { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
    }
}
