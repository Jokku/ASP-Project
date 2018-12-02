using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ASPNetCoreIdentity.Models;

namespace SportsStore.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        public int rating { get; set; }
        [Required]
        public string comment { get; set; }
        //[Required]
        //public AccountViewModels.LoginViewModel User { get; set; }
        [Required]
        public Product product { get; set; }
        [Required]
        public ApplicationUser user { get; set; }
    }
}
