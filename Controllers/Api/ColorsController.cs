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
    public class ColorsController : ControllerBase
    {
        private readonly CRContext _context;

        public ColorsController(CRContext context)
        {
            _context = context;
        }



        // POST: api/Colors

        [HttpPost]
        public async Task<ActionResult> PostColor(DtoColors.Post post)
        {
            tblColors NewColor = new tblColors();
            NewColor.ColorName = post.ColorName;
            _context.tblColors.Add(NewColor);
            await _context.SaveChangesAsync();
            return Ok(NewColor);
        }


        // Api/Colors

        [HttpGet]
        public async Task<ActionResult> GetAllColors()
        {
            var data = _context.tblColors.ToList();
            if (data.Count == 0) { return NotFound(); }
            return Ok(data);
        }


        // Api/Colors/2

        [HttpGet("{id}")]
        public async Task<ActionResult> GetColors(int id)
        {
            var data = _context.tblColors.Where(i => i.Id == id).ToList();
            if (data.Count == 0) { return NotFound(); }
            return Ok(data);
        }



        // PUT: api/Colors/5

        [HttpPut("{id}")]
        public async Task<ActionResult> EditColors(int id, DtoColors.Put EditedColor)
        {
            var data = _context.tblColors.FirstOrDefault(i => i.Id == id);
            if (data == null) { return NotFound(); }

            data.ColorName = EditedColor.ColorName;
            _context.tblColors.Update(data);
            await _context.SaveChangesAsync();
            return Ok(data);
        }



        // DELETE: api/colors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteColor(int id)
        {
            var data = _context.tblColors.FirstOrDefault(i => i.Id == id);
            if (data == null) { return NotFound(); }
            _context.tblColors.Remove(data);
            await _context.SaveChangesAsync();
            return Ok("Color has been deleted");
        }
    }
}
