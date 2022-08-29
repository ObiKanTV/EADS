using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EADS.Domain.Models.Entities;
using EADS.Domain.Models.DTOs;
using EADS.Domain.Interfaces.Repositories;

namespace EADS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EADSStringsController : ControllerBase
    {
        private readonly IEncStringRepository repo;

        public EADSStringsController(IEncStringRepository repo)
        {
            this.repo = repo;
        }

        // GET: api/EADSStrings/
        [HttpGet]
        public async Task<ActionResult<EncStringDTO>> GetEncStringData([FromBody] EADSRequestGetDTO request)
        {

            //var encStringData = await _context.EncStringData.FindAsync(id);

            return null;
        }
        // POST: api/EADSStrings
        [HttpPost]
        public async Task<ActionResult<EADSResponsePostDTO>> PostEncStringData([FromBody]EncStringDTO data)
        {
            //if (_context.EncStringData == null)
            //{
            //    return Problem("Entity set 'EADSContext.EncStringData'  is null.");
            //}
            EADSResponsePostDTO responsePostDTO = new();
            //  //_context.EncStringData.Add(encStringData);
            //  await _context.SaveChangesAsync();

            return CreatedAtAction("api/EADSStrings/{id}", responsePostDTO);
        }

        // DELETE: api/EADSStrings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEncStringData(string id)
        {
            //if (_context.EncStringData == null)
            //{
            //    return NotFound();
            //}
            //var encStringData = await _context.EncStringData.FindAsync(id);
            //if (encStringData == null)
            //{
            //    return NotFound();
            //}

            //_context.EncStringData.Remove(encStringData);
            //await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
