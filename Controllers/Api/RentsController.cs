using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalProject.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalProject.Model;

namespace CarRentalProject.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentsController : ControllerBase
    {
        private readonly CRContext _context;

        public RentsController(CRContext context)
        {
            _context = context;
        }



        // POST: api/Brands
        // اجاره ماشین
        [HttpPost]
        public async Task<ActionResult> RentCar (DtoRents.Post post)
        {
            tblRents newRent = new tblRents();
            if( post.CarsId == 0 || post.UsersId == 0){ return BadRequest(); }
            newRent.TblCarsId = post.CarsId;
            newRent.TblUsersId = post.UsersId;
            _context.TblRents.Add(newRent);

            //حالا بایستی قابل کرایه بودن آن ماشین را غیر فعال کنیم
            var car =_context.TblCars.FirstOrDefault(a => a.Id == post.CarsId);
            if(car.AvailabilityForRent==false){return BadRequest("این ماشین اجاره شده و هم اکنون دسترس نیست");}  //اگه اجاره داده بودیم تا وقتی دوباره برنرگده نمیشه اجاره ش داد

            
            car.AvailabilityForRent = false;
            _context.TblCars.Update(car);

            await _context.SaveChangesAsync();

            _context.TblUsers.ToList(); //برای اینکه کاربر رو نمایش بده
            return Ok( " اجاره شد " +newRent.TblUsers.UserName  + "  از طرف کاربر " + newRent.TblCars.Model + " ماشین ");

        }




        [HttpPut]
        public async Task<ActionResult> ReturnCar ( DtoRents.Put Put)
        {
            //tblRents UpdateRent = new tblRents();
            if (Put.CarsId == 0 || Put.UsersId == 0) { return BadRequest(); }

            var lastRent = _context.TblRents.OrderBy(a=>a.Id).LastOrDefault(a => a.TblCarsId == Put.CarsId);
            //lastRent.TblCarsId = Put.CarsId;
            //lastRent.TblUsersId = Put.UsersId;
            //lastRent.Id = id;
            //_context.TblRents.Update(UpdateRent);

            //حالا بایستی قابل دسترس بودن آن را فعال کنیم

            var data = _context.TblCars;
            var car = data.FirstOrDefault(a => a.Id == Put.CarsId);
            if(data==null || car==null){ return BadRequest("این ماشین در دسترس نیست"); }
            if (car.AvailabilityForRent == true) { return BadRequest("این ماشین اجاره نشده و در دسترس است"); }  

            car.AvailabilityForRent = true;
            _context.TblCars.Update(car);

            _context.SaveChanges();

            _context.TblUsers.ToList(); //برای اینکه کاربر رو نمایش بده
            return Ok(" برگردانده شد " + lastRent.TblUsers.UserName + "  از طرف کاربر " + lastRent.TblCars.Model + " ماشین ");
        }


    }
}
