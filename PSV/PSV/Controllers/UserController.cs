
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
    [ApiController]
    [Route("[controller]")]
    public class UserController : DefaultController
    {

        public UserController(ProjectConfiguration configuration) : base(configuration)
        {
        }

        [Route("/api/users/current")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(GetCurrentUser());
        }

        [Route("/api/users/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id) {
            return Ok(userService.Get(id));
        }

        [Route("/api/users")]
        [HttpGet]
        public async Task<IActionResult> GetAll(int id)
        {
            return Ok(userService.GetAll());
        }

        [Route("/api/users")]
        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {
            return Ok(userService.Add(user));
        }

        [Route("/api/users/{id}")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, User user)
        {
            return Ok(userService.Edit(id, user));
        }

        [Route("/api/users/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(userService.Delete(id));
        }

        [Route("/api/users/register")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(User user)
        {
            return Ok(userService.RegisterUser(user));
        }
    }
}
