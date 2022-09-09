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
    public class EADSDemoObjectsController : ControllerBase
    {
        private readonly IDemoPresentationEncRepository repo;

        public EADSDemoObjectsController(IDemoPresentationEncRepository repo)
        {
            this.repo = repo;
        }

        // GET: api/EADSDemoObjects/
        [HttpGet]
        public async Task<ActionResult<DemoPresentationObjectDTO>> GetDemoData(string id, string passPhrase)
        {
            if (id == null || passPhrase == null) return BadRequest("Missing Parameters");
            if (!await repo.Exists(id))
            {
                return NotFound();
            }
            var request = new EADSRequestGetDTO() {Id = id, PassPhrase = passPhrase };
            
            var response = await repo.Get(request);
            if(response == null) return NotFound("Could not be found or not be decrypted.");

            return Ok(response);
        }
        // POST: api/EADSDemoObjects/
        [HttpPost]
        public async Task<ActionResult<EADSResponsePostDTO>> PostDemoData(DemoPresentationObjectDTO data)
        {
            if (data == null) return BadRequest("Missing Parameters");
            var response = await repo.Add(data);

            
            return Ok(response);
        }

        // DELETE: api/EADSDemoObjects/
        [HttpDelete]
        public async Task<IActionResult> DeleteDemoObjectData(string id)
        {
            if (!await repo.Exists(id))
            {
                return NotFound();
            }

            await repo.Remove(id);
            return NoContent();
        }
        
    }
}
