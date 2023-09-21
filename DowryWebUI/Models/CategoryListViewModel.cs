using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace DowryWebUI.Models
{
    public class CategoryListViewModel
    {
        public IDataResult<List<Category>>? Categories { get; internal set; }
    }
}
