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


namespace PWO.Api.Controllers {

    [Route("api/[controller]")]
    public class ClaimsController : BaseController 
    {
        private const string FAILGETENTITIES = "Failed to get Todo from the API";
        private const string FAILGETENTITYBYID = "Failed to get Todo from the API by Id: {0}";

        public ClaimsController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager):base(applicationDbContext, userManager) 
        {
        }
        
        /* [HttpGet(Name = "GetClaims")]
        public IEnumerable<string> Get()
        {
            //var claimsPrincipalCurrent = System.Security.Claims.ClaimsPrincipal.Current;
            //return claimsPrincipalCurrent.FindFirst("name").Value;
            return new string[] { "claims1", "claims2" };
        } */

        [HttpGet]
        public IActionResult Get()
        {
            var scopes = HttpContext.User.FindFirst("http://schemas.microsoft.com/identity/claims/scope")?.Value;
            if (!string.IsNullOrEmpty(Startup.ScopeRead) && scopes != null
                    && scopes.Split(' ').Any(s => s.Equals(Startup.ScopeRead)))
                return Ok(new string[] { "value1", "value2" });
            else
                return Unauthorized();
        }
    }
}
