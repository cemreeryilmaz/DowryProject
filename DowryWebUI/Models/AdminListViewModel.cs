using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace DowryWebUI.Models
{
    public class AdminListViewModel
    {
        public IDataResult<List<Product>>? Products { get; set; }
        public IDataResult<List<Category>>? Categories { get; set; }
    }
}
