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
    public class EducationsController : ControllerBase
    {
        private readonly ResumeContext _context;

        public EducationsController(ResumeContext context)
        {
            _context = context;
        }
        // GET: api/Educations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Educations>>> GetEducations(int id)
        {
            if (_context.Education == null)
            {
                return NotFound();
            }
            var educations = await _context.Education.Where(r => r.info_id == id).ToListAsync();

            if (educations == null)
            {
                return NotFound();
            }

            return educations;
        }


    }

    internal class APIAuthKeyAttribute : Attribute
    {
    }
}
