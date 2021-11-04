using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalProject.Dto
{
    public class DtoGearboxType
    {
        public class Post
        {
            [Required]
            public string GearBoxTypeName { get; set; }
        }

        public class Put : DtoGearboxType.Post
        {

        }
    }
}
