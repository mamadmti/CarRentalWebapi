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
    public class CarsController : ControllerBase
    {
        private readonly CRContext _context;

        public CarsController(CRContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> PostNewCar(DtoCars.Post post)
        {
            tblCars NewCar = new tblCars();
            NewCar.Model = post.Model;
            NewCar.PlateNum = post.PlateNum;
            NewCar.ManufactorDate = post.ManufactorDate;
            NewCar.EngineModel = post.EngineModel;
            NewCar.tblBrandsId = post.BrandsId;
            NewCar.tblGearboxTypeId = post.GearboxTypeId;
            NewCar.tblColorsId = post.ColorsId;
            NewCar.AvailabilityForRent = true;

            _context.TblCars.Add(NewCar);

            await _context.SaveChangesAsync();
            return Ok(NewCar);
        }

       

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCar(int id,DtoCars.Put put)
        {
            
            
            var carinfos = _context.TblCars.Where(i => i.Id == id).FirstOrDefault();



            carinfos.Id = id;
            carinfos.Model = put.Model;
            carinfos.PlateNum = put.PlateNum;
            carinfos.ManufactorDate = put.ManufactorDate;
            carinfos.EngineModel = put.EngineModel;
            carinfos.tblBrandsId = put.BrandsId;
            carinfos.tblGearboxTypeId = put.GearboxTypeId;
            carinfos.tblColorsId = put.ColorsId;
            carinfos.AvailabilityForRent = carinfos.AvailabilityForRent;
            _context.TblCars.Update(carinfos);
            await _context.SaveChangesAsync();
            return Ok(carinfos);


        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCar(int id)
        {
            var data = _context.TblCars.FirstOrDefault(i => i.Id == id);
            if (data == null) { return NotFound(); }
            _context.TblCars.Remove(data);
            await _context.SaveChangesAsync();
            return Ok("Color has been deleted");
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCars()
        {
            var data = _context.TblCars.ToList();
            if (data.Count == 0) { return NotFound(); }
            return Ok(data);
        }


        // Api/Colors/2

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSpecificCar(int id)
        {
            var data = _context.TblCars.Where(i => i.Id == id).ToList();
            if (data.Count == 0) { return NotFound(); }
            return Ok(data);
        }

    }
}
