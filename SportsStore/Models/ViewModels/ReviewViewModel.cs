using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models.ViewModels
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public string comment { get; set; }
        public int rating { get; set; }
    }
}
