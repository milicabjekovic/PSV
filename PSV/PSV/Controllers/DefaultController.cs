
using Microsoft.AspNetCore.Mvc;
using PSV.Configuration;
using PSV.Model;
using PSV.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        protected UserService userService;
        
        protected ProjectConfiguration configuration;

        public DefaultController(ProjectConfiguration configuration)
        {
            this.configuration = configuration;
            
            this.userService = new UserService(configuration);
        }

        protected User GetCurrentUser()
        {
            string email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Email")?.Value;

            return userService.GetUserWithEmail(email);
        }
    }
}

