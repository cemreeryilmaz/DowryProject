using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, DowryContext>, ICategoryDal
    {
        //public List<CategoryWithProductsDto> GetByIdWithProducts(int categoryId)
        //{
        //    using (DowryContext context = new DowryContext())
        //    {
        //        var result = from c in context.Categories
        //                     join p in context.Products
        //                     on c.CategoryId equals p.CategoryId
        //                     select new CategoryWithProductsDto
        //                     {
        //                         CategoryId = c.CategoryId,
        //                         ProductName = p.ProductName,
        //                         UnitPrice = p.UnitPrice,
        //                         ImageUrl = p.ImageUrl,
        //                         PurchaseDate = p.PurchaseDate,
        //                         ProductId = p.ProductId,
        //                     };

        //        return result.ToList();
        //    }

        //}

        public Category GetByIdWithProducts(int categoryId)
        {
            using (var context = new DowryContext())
            {
                return context.Categories
                                .Where(c => c.CategoryId == categoryId)
                                .Include(c => c.Products)
                                .FirstOrDefault();
            }
        }

        public void DeleteFromCategory(int productId, int categoryId)
        {
            using (var context = new DowryContext())
            {
                var cmd = "delete from category where Ca = @p0 and CategoryId = @p1";
                context.Database.ExecuteSqlRaw(cmd, productId, categoryId);
            }
        }
    }
}

//using (DowryContext context = new DowryContext())
//{
//    var result = from p in context.Products
//                 join c in context.Categories
//                 on p.CategoryId equals c.CategoryId
//                 select new ProductDetailDto
//                 {
//                     ProductId = p.ProductId,
//                     ProductName = p.ProductName,
//                     CategoryName = c.CategoryName,
//                     UnitPrice = p.UnitPrice,
//                     Description = p.Description,
//                     ImageUrl = p.ImageUrl,
//                     PurchaseDate = p.PurchaseDate,
//                     Url = p.Url

//                 };
//    return result.ToList();
//}
