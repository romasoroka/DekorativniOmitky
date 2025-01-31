using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Data;
using WebSite.DataAccess.Repository.IRepository;
using WebSite.Models;

namespace WebSite.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context): base(context) 
        {
            _context = context;
        }
        public void Update(Product product)
        {
            var obj = _context.Products.FirstOrDefault(obj => obj.Id == product.Id);
            if (obj != null)
            {
                obj.ISBN = product.ISBN;
                obj.Author = product.Author;
                obj.Description = product.Description;
                obj.Price = product.Price;
                obj.Price50 = product.Price50;
                obj.Price100 = product.Price100;
                obj.ListPrice = product.ListPrice;
                obj.CategoryId = product.CategoryId;
                if (product.ImageURL != null)
                {
                    obj.ImageURL = product.ImageURL;
                }
            }
        }
    }
}
