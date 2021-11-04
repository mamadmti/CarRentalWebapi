using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalProject.Dto
{
    public class DtoRents
    {

        public class Post
        {
            [Required]
            public int UsersId { get; set; }

            [Required]
            public int CarsId { get; set; }

        }

        public class Put:Post
        {
            [Required]
            public int Id { get; set; }
        }

        public class Show : Put
        {
        }
    }
}
