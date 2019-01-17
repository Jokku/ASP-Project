using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using SportsStoreServices;

namespace SportsStore.Controllers
{
    public class ReviewController : Controller
    {
        private ReviewService rev;
        public ReviewController(ReviewService r)
        {
            rev = r;
        }
        public IActionResult Index()
        {
            var reviews = rev.GetAll();
            var listingResult = reviews.Select(result => new ReviewViewModel { Id = result.Id, comment = result.comment, rating = result.rating });

            var model = new ReviewIndexModel()
            {
                Reviews = listingResult
            };
            return View(model);
        }


    }
}