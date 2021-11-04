using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalProject.Dto
{
    public class DtoColors
    {
        public class Post
        {
            [Required]
            public string ColorName { get; set; }
        }

        public class Put : DtoColors.Post
        {

        }
    }
}
