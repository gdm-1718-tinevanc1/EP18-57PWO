using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using PWO.Db;
using PWO.Models;
using PWO.Models.Security;

namespace PWO.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : BaseController
    {
        private const string FAILGETENTITIES = "Failed to get Todo from the API";
        private const string FAILGETENTITYBYID = "Failed to get Todo from the API by Id: {0}";

        public ProjectsController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager):base(applicationDbContext, userManager) 
        {
        }

        // GET api/projects
        [HttpGet(Name = "GetProjects")]
        public async Task<IActionResult> GetProjects([FromQuery] Nullable<bool> withChildren)
        {
            var model = (withChildren != null && withChildren == true)?await ApplicationDbContext.Projects.Include(f => f.Financingform)
            .Include(m => m.Media).ToListAsync():await ApplicationDbContext.Projects.ToListAsync();

            /*var model = (withChildren != null && withChildren == true)?await ApplicationDbContext.Projects.Include(l => l.Location.City.Country)
            .Include(a => a.AccomodationType).Include(a => a.AccomodationPrice).Include(a => a.RentalType)
            .Include(a => a.Image).Include(a => a.Reviews).Include(a => a.Accessibilities)
            .Include(a => a.FoodIncludeds).Include(a => a.Services).Include(a => a.Rooms).ToListAsync():await ApplicationDbContext.Projects.ToListAsync(); */

           
            if (model == null)
            {
                var msg = String.Format(FAILGETENTITIES);
                return NotFound(msg);
            }
            return new OkObjectResult(model);
        }

        [HttpGet("{projectId:int}", Name = "GetprojectById")]
        public async Task<IActionResult> GetProjectById(Int16 projectId)
        {
            var model = await ApplicationDbContext.Projects.FirstOrDefaultAsync(o => o.Id == projectId);
            if (model == null)
            {
                var msg = String.Format(FAILGETENTITYBYID, projectId);
                return NotFound(msg);
            }
            return new OkObjectResult(model);
        }
    }
}
