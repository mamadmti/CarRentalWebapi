using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace CarRentalProject.Model
{
    public class tblUsers
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }

    }
}
