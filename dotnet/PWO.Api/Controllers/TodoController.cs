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
    // private readonly TodoContext _context;

    [Route("api/[controller]")]
    public class TodoController : BaseController
    {
        private const string FAILGETENTITIES = "Failed to get Todo from the API";
        private const string FAILGETENTITYBYID = "Failed to get Todo from the API by Id: {0}";

        public TodoController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager):base(applicationDbContext, userManager) 
        {
        }


        // async Task<IActionResult>
        [HttpGet(Name = "GetTodos")]
         public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        /* public async Task<IActionResult> GetTodos()
        {
            var model = await ApplicationDbContext.Todos.ToListAsync();
            
            if (model == null)
            {
                var msg = String.Format(FAILGETENTITIES);
                return NotFound(msg);
            }
            return new OkObjectResult(model);
            
        } */
      /*  private const string FAILGETENTITIES = "Failed to get Accessibilities from the API";
        private const string FAILGETENTITYBYID = "Failed to get Accessibility from the API by Id: {0}";

        // GET api/Todo
        [HttpGet(Name = "GetTodos")]
        public async Task<IActionResult> GetTodos()
        {
             _context = context;

            var model = await _context.Todos.ToListAsync();
            if (model == null)
            {
                var msg = String.Format(FAILGETENTITIES);
                return NotFound(msg);
            }
            return new OkObjectResult(model);
        } */
    }
}
