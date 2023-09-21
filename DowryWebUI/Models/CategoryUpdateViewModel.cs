using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace DowryWebUI.Models
{
    public class CategoryUpdateViewModel
    {
        public Category? Category { get; set; }
        public List<Product>? Products { get; set; }
    }
}
