using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resume.Data;
//using Resume.Helpers;
using Resume.Models;

namespace Resume.APIController
{
    [APIAuthKey]
    [Route("api/[controller]")]
    [ApiController]
    public class ReferencesController : ControllerBase
    {
        private readonly ResumeContext _context;

        public ReferencesController(ResumeContext context)
        {
            _context = context;
        }


        // GET: api/References/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<References>>> GetReferences(int id)
        {
          if (_context.Reference == null)
          {
              return NotFound();
          }
            var references = await _context.Reference.Where(r => r.info_id == id).ToListAsync();

            if (_context.Reference == null)
            {
                return NotFound();
            }

            return references;
        }

        
    }
}
