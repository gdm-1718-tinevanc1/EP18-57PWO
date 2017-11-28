using Microsoft.AspNetCore.Mvc;
using OpenIddict;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PWO.Db;
using PWO.Models.Security;

namespace PWO.Api.Controllers {

    public class BaseController : Controller {
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        public BaseController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager) {
            ApplicationDbContext = applicationDbContext;
            UserManager = userManager;
        }
    }
}