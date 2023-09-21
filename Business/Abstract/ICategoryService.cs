using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetById(int categoryId);
        IDataResult<Category> GetByIdWithProducts(int categoryId);
        void DeleteFromCategory(int productId, int categoryId);
        IResult Add(Category category);
        IResult Update(Category category);
    }
}
