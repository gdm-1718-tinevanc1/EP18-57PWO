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
    public class ProfilesController : BaseController
    {
        private const string FAILGETENTITIES = "Failed to get Todo from the API";
        private const string FAILGETENTITYBYID = "Failed to get Todo from the API by Id: {0}";

        public ProfilesController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager):base(applicationDbContext, userManager) 
        {
        }

        // GET api/profiles
        [HttpGet(Name = "GetProfiles")]
        public async Task<IActionResult> GetProfiles([FromQuery] Nullable<bool> withChildren)
        {
            var model = (withChildren != null && withChildren == true)?await ApplicationDbContext.Profiles.ToListAsync():await ApplicationDbContext.Profiles.ToListAsync();

            /*var model = (withChildren != null && withChildren == true)?await ApplicationDbContext.Profiles.Include(l => l.Location.City.Country)
            .Include(a => a.AccomodationType).Include(a => a.AccomodationPrice).Include(a => a.RentalType)
            .Include(a => a.Image).Include(a => a.Reviews).Include(a => a.Accessibilities)
            .Include(a => a.FoodIncludeds).Include(a => a.Services).Include(a => a.Rooms).ToListAsync():await ApplicationDbContext.Profiles.ToListAsync(); */

           
            if (model == null)
            {
                var msg = String.Format(FAILGETENTITIES);
                return NotFound(msg);
            }
            return new OkObjectResult(model);
        }

        [HttpGet("{profileId:int}", Name = "GetprofileById")]
        public async Task<IActionResult> GetProfileById(Int16 profileId)
        {
            var model = await ApplicationDbContext.Profiles.FirstOrDefaultAsync(o => o.Id == profileId);
            if (model == null)
            {
                var msg = String.Format(FAILGETENTITYBYID, profileId);
                return NotFound(msg);
            }
            return new OkObjectResult(model);
        }
    }
}
