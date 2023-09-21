using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new DowryContext();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(Categories);
                }

                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                }
            }
            context.SaveChanges();
        }

        private static Category[] Categories = {
            new Category(){CategoryName="Mutfak Eşyaları",ImageUrl="deneme.png"},
            new Category(){CategoryName="Banyo Eşyaları",ImageUrl="deneme.png"},
            new Category(){CategoryName="Mobilya",ImageUrl="deneme.png"},
            new Category(){CategoryName="Beyaz Eşyalar",ImageUrl="deneme.png"},
            new Category(){CategoryName = "Elektrikli Aletler", ImageUrl = "deneme.png"},
            new Category(){CategoryName = "Diğer Ev Eşyaları", ImageUrl = "deneme.png"},
            new Category(){CategoryName = "Ev Tekstili", ImageUrl = "deneme.png"},
            new Category(){CategoryName = "Ev Aksesuarları", ImageUrl = "deneme.png"},
        };

        private static Product[] Products = {
            new Product(){ProductName="Ayak Havlusu", UnitPrice=100 ,ImageUrl="1.jpg",CategoryId=1,PurchaseDate=DateTime.Now},
            new Product(){ProductName="Buzdolabı",UnitPrice = 20000, ImageUrl = "2.jpg",CategoryId=3,PurchaseDate=DateTime.Now},
            new Product(){ProductName="Yüz Havlusu",UnitPrice = 200, ImageUrl = "3.jpg",CategoryId=1,PurchaseDate=DateTime.Now},
            new Product(){ProductName="Mikser",UnitPrice = 1000, ImageUrl = "4.jpg",CategoryId=2,PurchaseDate=DateTime.Now},
            new Product(){ProductName="Fırın",UnitPrice = 5000, ImageUrl = "5.jpg",CategoryId=3,PurchaseDate=DateTime.Now,},
        };  

    }
}