using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models.ViewModels
{
    public class ProductReviewViewModel
    {
       
        public Product Product { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public ProductReviewViewModel(Product p, IEnumerable<Review> r)
        {
            Product = p;
            Reviews = r;
        }
    }
}
