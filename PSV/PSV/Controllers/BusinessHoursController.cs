
using Microsoft.AspNetCore.Mvc;
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
    public class BusinessHoursController : Controller
    {
        public BusinessHoursService businessService = new BusinessHoursService();

        [Route("/api/businessHours")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(businessService.GetAll());
        }

        [Route("/api/businessHours")]
        [HttpPost]
        public async Task<IActionResult> Add(BusinessHours business)
        {
            return Ok(businessService.Add(business));
        }
    }
}
