using Microsoft.AspNetCore.Mvc;
using PSV.Configuration;
using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PSV.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IntegrationController : DefaultController
    {
        public IntegrationController(ProjectConfiguration configuration) : base(configuration)
        {
        }

       [Route("/api/getDrugs")]
        [HttpGet]
        public async Task<IActionResult> getDrugs()
        {
           
            return Ok();
        }

        [Route("/api/getOrderDrugs")]
        [HttpGet]
        public async Task<IActionResult> getOrderDrugs()
        {
            
            return Ok();
        }


        [Route("/api/createOrderDrug")]
        [HttpPost]
        public async Task<IActionResult> createOrderDrug(OrderRequest data)
        {
           
            return Ok();
        }


    }
}
