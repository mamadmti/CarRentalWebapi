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

            _context.TblCars.Add(NewCar);
            await _context.SaveChangesAsync();
            return Ok(NewCar);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> GetBrand(int id,DtoCars.Put put)
        {
            var data = _context.TblCars.Where(i => i.Id == id).ToList();
            if (data.Count == 0) { return NotFound(); }

            tblCars NewCar = new tblCars();
            NewCar.Id = put.Id;
            NewCar.Model = put.Model;
            NewCar.PlateNum = put.PlateNum;
            NewCar.ManufactorDate = put.ManufactorDate;
            NewCar.EngineModel = put.EngineModel;
            NewCar.tblBrandsId = put.BrandsId;
            NewCar.tblGearboxTypeId = put.GearboxTypeId;
            NewCar.tblColorsId = put.ColorsId;

            _context.TblCars.Update(NewCar);
            await _context.SaveChangesAsync();
            return Ok(NewCar);
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
