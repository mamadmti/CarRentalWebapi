using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalProject.Dto
{
    public class DtoBrands
    {
        public class Post
        {
           [Required]
           public string BrandName { get; set; }
        }

        public class Put:Post
        {
            
        }


    }
}
