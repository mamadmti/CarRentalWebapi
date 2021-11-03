using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalProject.Model;

namespace CarRentalProject.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CRContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.TblUsers.Any())
            {
                return;   // DB has been seeded
            }
            var Users = new tblUsers[]
            {
                
                new tblUsers{IsAdmin=true,UserName="Admin"},
                new tblUsers{IsAdmin=false,UserName="User"}
            };
            foreach (tblUsers s in Users)
            {
                context.TblUsers.Add(s);
            }
            context.SaveChanges();
        }
    }

}
