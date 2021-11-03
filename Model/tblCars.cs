using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalProject.Model
{
    public class tblCars
    {
        public int Id { get; set; }

        /// ارتباط با جدول برند
        public tblBrands TblBrands { get; set; }
        public int TblBrandsId { get; set; }
        //ارتباط با جدول رنگ ها
        public tblColors tblColors { get; set; }
        public int tblColorsId { get; set; }
        //ارتباط با جدول نوع گیربکس ها
        public tblGearboxTypes tblGearboxType { get; set; }
        public int tblGearboxTypeId { get; set; }

        public string Color { get; set; }

        public string PlateNum { get; set; }
        public string GearBoxType { get; set; } 
        public string Model { get; set; }
        public string EngineModel { get; set; }
        public DateTime ManufactorDate { get; set; }
        public bool AvailabilityForRent { get; set; }

    }
}
