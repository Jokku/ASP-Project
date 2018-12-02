using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;
using SportsStore.Models.ViewModels;
using SportsStoreServices;
using System.Threading.Tasks;
using System;
namespace SportsStore.Controllers
{

    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        private ProductService product;
        private ReviewService review;//new


        public ProductController(IProductRepository repo, ProductService p, ReviewService r)
        {
            repository = repo;
            this.product = p;
            this.review = r;//new
        }

        public ViewResult List(string category, int productPage = 1)
            => View(new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        repository.Products.Count() :
                        repository.Products.Where(e =>
                            e.Category == category).Count()
                },
                CurrentCategory = category
            });

        public IActionResult Detail(int id)
        {
            var pdetail = product.GetById(id);
            var pReview = review.GetByProduct(pdetail);

            ProductReviewViewModel model = new ProductReviewViewModel(pdetail, pReview);

            //var listingResult = pdetail.Select(result => new ProductDetailViewModel { ProductId = result.Id, Name = result.Name, Category = result.Category, Description = result.Description, Price = result.Price, Reviews = result.Reviews });

            // var model = new ProductReviewViewModel()
            // {
            //   productDetails = listingResult
            // };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddReview(Review model)
        {
            
            string url = this.Request.Path;
            if (ModelState.IsValid)
            {
                review.Add(model);
            }
            return Redirect("http://localhost:53406/Product/Detail/1");
        }
    }
}
