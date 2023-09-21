using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void DeleteFromCategory(int productId, int categoryId)
        {
            _categoryDal.DeleteFromCategory(productId, categoryId);
        }

        public IResult Add(Category category)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExists(category.CategoryName));
            if (result != null)
            {
                return result;
            }

            _categoryDal.Add(category);
            return new SuccessResult("Ürün Eklendi.");
        }

        private IResult CheckIfProductNameExists(string categoryName)
        {
            var result = _categoryDal.GetAll(c => c.CategoryName == categoryName).Any();
            if (result)
            {
                return new ErrorResult("Bu isimde zaten başka bir kategori vardır.");
            }
            return new SuccessResult("Bu isimde kategori yok.");
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == categoryId));
        }

        public IDataResult<Category> GetByIdWithProducts(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.GetByIdWithProducts(categoryId));
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult("Kategori Güncellendi.");
        }

    }
}
