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
        public int PageSize = 8;

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

        public IActionResult WriteReviews()
        {
           if(AccountController.uname == null)
            {
               // return Redirect("http://localhost:53406/Account/Login/");
               return RedirectToAction("Login", "Account");
            }
           else
            {
                return View();
            }
            
        }

        [HttpPost]
        public IActionResult AddReview(Review rev)
        {
            // ProductReviewViewModel pr = model;
            //Console.WriteLine("Model " + model.product);
            //var listingResult = pr.Reviews.Select(result => new Review { comment = result.comment, rating = result.rating, product = result.product, user = result.user} );
            var p = product.GetById(rev.Id);
            var review = new Review { comment = rev.comment, product = p, rating = rev.rating };
            this.review.Add(review);
            //Console.WriteLine("rating " + rating + "comment "+comment);
           // return Redirect("http://localhost:53406/Product/Detail/"+rev.Id);
            return RedirectToAction("Detail", "Product", new { id = rev.Id });
        }
        public IActionResult Search(string search = null)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var foundproducts = repository.SearchProducts(search);
                var productListViewModel = new ProductsListViewModel
                {
                    Products = foundproducts
                };

                return View(productListViewModel);
            }

            return View();

        }

            
    }
}
