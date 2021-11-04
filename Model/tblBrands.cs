using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalProject.Model
{
    public class tblBrands
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string BrandName { get; set; }

    }
}
