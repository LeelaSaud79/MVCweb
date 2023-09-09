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
    public class SkillsController : ControllerBase
    {
        private readonly ResumeContext _context;

        public SkillsController(ResumeContext context)
        {
            _context = context;
        }

        // GET: api/Skills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Skills>>> GetSkills(int id)
        {
          if (_context.Skills == null)
          {
              return NotFound();
          }
            var skills = await _context.Skills.Where(r => r.info_id == id).ToListAsync();

            if (_context.Skills == null)
            {
                return NotFound();
            }

            return skills;
        }

       
    }
}
