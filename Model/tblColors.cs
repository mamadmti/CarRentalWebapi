using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalProject.Model
{
    public class tblColors
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ColorName { get; set; }
    }
}
