using Microsoft.AspNetCore.Mvc;
using PSV.Configuration;
using PSV.Model;
using PSV.Services;
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

        public PurchaseDrugService service = new PurchaseDrugService(); 

        [Route("/api/getDrugs")]
        [HttpGet]
        public async Task<IActionResult> getDrugs()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("http://localhost:8081/drugs/getAll");
            return Ok(await response.Content.ReadAsStringAsync());
        }

        [Route("/api/getOrderDrugs")]
        [HttpGet]
        public async Task<IActionResult> getOrderDrugs()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("http://localhost:8081/orderDrugs/getAll");
            return Ok(await response.Content.ReadAsStringAsync());
        }


        [Route("/api/createOrderDrug")]
        [HttpPost]
        public async Task<IActionResult> createOrderDrug(OrderRequest data)
        {
            HttpClient client = new HttpClient();

            string json = JsonSerializer.Serialize(data);

            var response = await client.PostAsync("http://localhost:8081/orderDrugs/order", new StringContent(json));
            return Ok(await response.Content.ReadAsStringAsync());
        }


        [Route("/api/getPharmacyDrugs")]
        [HttpGet]
        public async Task<IActionResult> getPharmacyDrugs()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("http://localhost:8081/pharmacyDrugs/getAll");
            return Ok(await response.Content.ReadAsStringAsync());
        }

        [Route("/api/getPurchasePharmacyDrugs/{id}/{idd}")]
        [HttpGet]
        public async Task<IActionResult> getPurchasePharmacyDrugs(long id, long idd)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("http://localhost:8081/pharmacyDrugs/getPurchasePharmacyDrugs/" + id + "/" + idd);
            PurchaseDrug drug = new PurchaseDrug();
            drug.DrugId = (int)id;
            drug.PharmacyId = (int)idd;
            service.Add(drug);
            return Ok(await response.Content.ReadAsStringAsync());
        }

    }
}
