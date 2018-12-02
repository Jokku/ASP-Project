using System;
using System.Collections.Generic;
using SportsStore.Models;
using System.Linq;

namespace SportsStoreServices
{
    public class ReviewService
    {
        private ApplicationDbContext _context;

        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Review> GetAll()
        {
            return _context.Reviews;
        }

        public void Add(Review rev)
        {
            _context.Add(rev);
            _context.SaveChanges();
        }

        public Review GetComment(int Id)
        {
           return _context.Reviews.FirstOrDefault(a => a.Id == Id);
        }

        public IEnumerable<Review> GetByProduct(Product p)
        {
            return GetAll().Where(a => a.product == p);
        }
    }
}
