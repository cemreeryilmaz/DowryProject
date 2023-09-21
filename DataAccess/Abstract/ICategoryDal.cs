using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        void DeleteFromCategory(int productId, int categoryId);
        Category GetByIdWithProducts(int categoryId);

    }
}
