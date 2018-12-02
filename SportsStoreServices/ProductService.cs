using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportsStoreServices
{
   public class ProductService
    {
        private ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }

        public Product GetById(int Id)
        {
            return GetAll().FirstOrDefault(a => a.ProductID == Id);
        }
    }
}
