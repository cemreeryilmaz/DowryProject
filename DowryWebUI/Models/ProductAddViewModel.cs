using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace DowryWebUI.Models
{
    public class ProductAddViewModel
    {
        public Product Product { get; set; }
        public IDataResult<List<Category>>? Categories { get; internal set; }
    }
}
