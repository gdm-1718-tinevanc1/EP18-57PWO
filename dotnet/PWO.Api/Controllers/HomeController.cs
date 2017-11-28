using Microsoft.AspNetCore.Mvc;
using OpenIddict;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PWO.Db;
using PWO.Models.Security;

namespace PWO.Api.Controllers {

    public class HomeController : BaseController {

        public HomeController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager):base(applicationDbContext, userManager) 
        {
        }
    }
}