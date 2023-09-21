using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DowryWebUI.Models
{
    public class ProductListViewModel
    {
        public IDataResult<Product>? Product { get; set; }
        public IDataResult<List<ProductDetailDto>>? Products { get; set; }
        public IDataResult<List<Category>>? Categories { get; internal set; }
    }
}
