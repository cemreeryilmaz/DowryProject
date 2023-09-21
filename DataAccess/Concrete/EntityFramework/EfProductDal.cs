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
    public class EfProductDal : EfEntityRepositoryBase<Product, DowryContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (DowryContext context = new DowryContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {                                 
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitPrice = p.UnitPrice,
                                 ImageUrl = p.ImageUrl,
                                 PurchaseDate = p.PurchaseDate,
                                 
                             };
                return result.ToList();
            }
        }

      
    }


}