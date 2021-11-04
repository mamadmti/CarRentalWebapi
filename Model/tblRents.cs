using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalProject.Model
{
    public class tblRents
    {
        [Required]
        public int Id { get; set; }

        // ارتباط با جدول یوزرز
        public tblUsers TblUsers { get; set; }
        [Required]
        public int TblUsersId { get; set; }

        //ارتباط با جدول ماشین ها
        public tblCars TblCars { get; set; }
        [Required]
        public int TblCarsId { get; set; }


    }
}
