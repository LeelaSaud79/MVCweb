using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Resume.Data;
using Resume.Helpers;
using Resume.Models;

//namespace Resume.APIController
//{
//    //[APIKeyAuth]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class InfoesController : ControllerBase
//    {
//        private readonly ResumeContext _context;

//        //private const String ApiUsername = "username";
//        //private const String ApiPassword = "password";

//        public InfoesController(ResumeContext context)
//        {
//            _context = context;
//        }

//        //[HttpGet]
//        //[Route("/login")]
//        //public async Task<ActionResult<Info>> Login()
//        //{
//        //    if (!HttpContext.Request.Headers.TryGetValue(ApiUsername, out var email) ||
//        //       !HttpContext.Request.Headers.TryGetValue(ApiPassword, out var passkey))
//        //    {
//        //        return BadRequest("bad request");
//        //    }
//        //    else
//        //    {
//        //        var emailId = await _context.Info.Where(r => r.email == email.ToString()).FirstOrDefaultAsync();
//        //        if (emailId == null)
//        //        {
//        //            return NotFound("Invalid email");
//        //        }
//        //        if (emailId.password != passkey.ToString())
//        //        {
//        //            return NotFound("incorrect password");
//        //        }
//        //        return emailId;
//        //    }
//        //}



//        // GET: api/Infoes/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<List<Info>>> GetInfo(int id)
//        {
//          if (_context.Info == null)
//          {
//              return NotFound();
//          }
//            var info = await _context.Info.Where(r => r.info_id == id).ToListAsync();

//            if (_context.Info == null)   
//            {
//                return NotFound();
//            }

//            return info;
//        }
//    }
//}
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using ResumeProject.Data;
//using ResumeProject.Helpers;
//using ResumeProject.Models;
//namespace ResumeProject.APIControllers
//{
//    [APIKeyAuth]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class InfosController : ControllerBase
//    {
//        private readonly ResumeProjectContext _context;
//        public InfosController(ResumeProjectContext context)
//        {
//            _context = context;
//        }
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Infos>> GetInfos(int id)
//        {
//            if (_context.Infos == null)
//            {
//                return NotFound();
//            }
//            var infos = await _context.Infos.FindAsync(id);
//            if (infos == null)
//            {
//                return NotFound();
//            }
//            return infos;
//        }
//    }
//}

namespace Resume.APIControllers
{
    //[APIAuthKey]
    [Route("api/[controller]")]
    [ApiController]
    public class InfosController : ControllerBase
    {
        private readonly ResumeContext _context;
        public InfosController(ResumeContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("~/api/login")]
        public async Task<ActionResult<Info>> GetInfos()
        {
            HttpContext.Request.Headers.TryGetValue("UserEmail", out var userEmail);
            HttpContext.Request.Headers.TryGetValue("Password", out var password);
            if (string.IsNullOrEmpty(userEmail) && string.IsNullOrEmpty(password))
            {
                return BadRequest("Email and password are required.");
            }
            if (_context.Info == null)
            {
                return NotFound();
            }
            var info = await _context.Info.Where(info => info.email == userEmail.ToString()).FirstAsync();
            if (info == null)
            {
                return NotFound("No information");
            }
            if (info.password != password.ToString())
            {
                return NotFound("Wrong password");
            }
            return info;
        }

        // GET: api/Experiences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Info>>> GetInfo(int id)
        {
            if (_context.Info == null)
            {
                return NotFound();
            }
            var info = await _context.Info.Where(r => r.info_id == id).ToListAsync();

            if (_context.Info == null)
            {
                return NotFound();
            }

            return info;
        }
    }
}













