using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalProject.Model
{
    public class tblCars
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string PlateNum { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string EngineModel { get; set; }
        [Required]
        public DateTime ManufactorDate { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool AvailabilityForRent { get; set; }




        /// ارتباط با جدول برند
        public tblBrands tblBrands { get; set; }
        [Required]
        public int tblBrandsId { get; set; }
        //ارتباط با جدول رنگ ها
        public tblColors tblColors { get; set; }
        [Required]
        public int tblColorsId { get; set; }

        //ارتباط با جدول نوع گیربکس ها
        public tblGearboxTypes tblGearboxType { get; set; }
        [Required]
        public int tblGearboxTypeId { get; set; }
       
    }
}
