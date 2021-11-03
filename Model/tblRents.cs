using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalProject.Model
{
    public class tblRents
    {
        public int Id { get; set; }

        // ارتباط با جدول یوزرز
        public tblUsers TblUsers { get; set; }
        public int TblUsersId { get; set; }

        //ارتباط با جدول ماشین ها
        public tblCars TblCars { get; set; }
        public int TblCarsId { get; set; }


    }
}
