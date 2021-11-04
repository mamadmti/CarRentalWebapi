using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalProject.Dto
{
    public class DtoCars
    {
        public class Post
        {

            [Required]
            public string PlateNum { get; set; }
            [Required]
            public string Model { get; set; }
            [Required]
            public string EngineModel { get; set; }
            [Required]
            public DateTime ManufactorDate { get; set; }

            [Required]
            public int BrandsId { get; set; }
            [Required]
            public int ColorsId { get; set; }
            [Required]
            public int GearboxTypeId { get; set; }
        }

        public class Put:Post
        {
            [Required]
            public int Id { get; set; }
        }
        
    }
}
