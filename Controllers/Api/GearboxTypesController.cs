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
    public class GearboxTypesController : ControllerBase
    {
        private readonly CRContext _context;

        public GearboxTypesController(CRContext context)
        {
            _context = context;
        }



        // POST: api/GearboxType

        [HttpPost]
        public async Task<ActionResult> PostGearboxTypes (DtoGearboxType.Post post)
        {
            tblGearboxTypes newGearbox = new tblGearboxTypes();
            newGearbox.GearBoxTypeName = post.GearBoxTypeName;

            _context.tblGearboxTypes.Add(newGearbox);
            await _context.SaveChangesAsync();

            return Ok(newGearbox);
        }


        // Api/GearboxType

        [HttpGet]
        public async Task<ActionResult> GetAllGearboxType()
        {
            var data = _context.tblGearboxTypes.ToList();
            if (data.Count == 0) { return NotFound(); }
            return Ok(data);
        }


        // Api/GearboxType/2

        [HttpGet("{id}")]
        public async Task<ActionResult> GetGearboxType(int id)
        {
            var data = _context.tblGearboxTypes.Where(i => i.Id == id).ToList();
            if (data.Count == 0) { return NotFound(); }
            return Ok(data);
        }



        // PUT: api/GearboxType/5

        [HttpPut("{id}")]
        public async Task<ActionResult> EditGearboxType(int id, DtoGearboxType.Put EditedGearboxType)
        {
            var data = _context.tblGearboxTypes.FirstOrDefault(i => i.Id == id);
            if (data == null) { return NotFound(); }

            data.GearBoxTypeName = EditedGearboxType.GearBoxTypeName;
            _context.tblGearboxTypes.Update(data);
            await _context.SaveChangesAsync();
            return Ok(data);
        }



        // DELETE: api/GearboxType/5

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGearboxType(int id)
        {
            var data = _context.tblGearboxTypes.FirstOrDefault(i => i.Id == id);
            if (data == null) { return NotFound(); }
            _context.tblGearboxTypes.Remove(data);
            await _context.SaveChangesAsync();
            return Ok("GearboxType has been deleted");
        }


    }
}
