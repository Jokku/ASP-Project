using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models.ViewModels
{
    public class ProductDetailIndexViewModel
    {
        public IEnumerable<ProductDetailViewModel> productDetails { get; set; }
    }
}
