using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.ComponentModel.DataAnnotations;

namespace DowryWebUI.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? ImageUrl { get; set; }
        public List<Product>? Products { get; set; }


    }
}
