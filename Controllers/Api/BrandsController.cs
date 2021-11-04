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
    public class BrandsController : ControllerBase
    {
        private readonly CRContext _context;

        public BrandsController(CRContext context)
        {
            _context = context;
        }




        // POST: api/Brands

        [HttpPost]
        public async Task<ActionResult> PostBrands(DtoBrands.Post post)
        {
            tblBrands newbrand = new tblBrands();
            newbrand.BrandName = post.BrandName;

            _context.TblBrands.Add(newbrand);
            await _context.SaveChangesAsync();

            return Ok(newbrand);
        }


        // Api/brands

        [HttpGet]
        public async Task<ActionResult> GetAllBrands()
        {
            var data = _context.TblBrands.ToList();
            if (data.Count == 0) { return NotFound(); }
            return Ok(data);
        }


        // Api/brands/2

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBrand(int id)
        {
            var data = _context.TblBrands.Where(i => i.Id == id).ToList();
            if (data.Count == 0){return NotFound();}
            return Ok(data);
        }



        // PUT: api/Brands/5

        [HttpPut("{id}")]
        public async Task<ActionResult> EditBrand(int id, DtoBrands.Put EditedBrand)
        {
            var data = _context.TblBrands.FirstOrDefault(i => i.Id == id);
            if (data == null){  return NotFound() ;}

            data.BrandName = EditedBrand.BrandName;
            _context.TblBrands.Update(data);
            await _context.SaveChangesAsync();
            return Ok(data);
        }



        // DELETE: api/Brands/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBrand(int id)
        {
            var data = _context.TblBrands.FirstOrDefault(i => i.Id == id);
            if (data == null) { return NotFound(); }
            _context.TblBrands.Remove(data);
            await _context.SaveChangesAsync();
            return Ok("Brand has been deleted");
        }



    }
}
