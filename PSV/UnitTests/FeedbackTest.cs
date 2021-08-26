using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSV.Configuration;
using PSV.Controllers;
using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class FeedbackTest
    {
        [TestMethod]
        public async Task GetAllAdminFeedbacksTestAsync() 
        {
            ProjectConfiguration projectConfiguration = new ProjectConfiguration();
            projectConfiguration.DatabaseConfiguration = new DatabaseConfiguration();
            projectConfiguration.DatabaseConfiguration.ConnectionString = "Server=DESKTOP-HEAPRGO\\SQLEXPRESS;Initial Catalog=psvTest;Trusted_Connection=True";

            FeedbackController controller = new FeedbackController(projectConfiguration);
            IActionResult result = await controller.GetAllAdminFeedbacks();
           

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            OkObjectResult objectResult = result as OkObjectResult;

            List<Feedback> list = objectResult.Value as List<Feedback>;

            foreach (Feedback feed in list) {

                Assert.IsTrue(feed.IsPublish);
                Assert.IsNotNull(feed.PatientEmail);
                
            }

            Assert.AreEqual(list.Count, 2);

            Assert.IsNotNull(objectResult);
        }

        [TestMethod]
        public async Task getAllPatinetFeedbacksTestAsync() {


            ProjectConfiguration projectConfiguration = new ProjectConfiguration();
            projectConfiguration.DatabaseConfiguration = new DatabaseConfiguration();
            projectConfiguration.DatabaseConfiguration.ConnectionString = "Server=DESKTOP-HEAPRGO\\SQLEXPRESS;Initial Catalog=psvTest;Trusted_Connection=True";

            FeedbackController controller = new FeedbackController(projectConfiguration);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
                                        new Claim(ClaimTypes.NameIdentifier, "SomeValueHere"),
                                        new Claim("Email", "milicabjekovic@gmail.com")
                                        // other required and custom claims
                                   }, "TestAuthentication"));
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.User = user;

            IActionResult result = await controller.getAllPatinetFeedbacks();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            OkObjectResult objectResult = result as OkObjectResult;

            List<Feedback> list = objectResult.Value as List<Feedback>;

            foreach (Feedback feed in list)
            {

                Assert.IsTrue(feed.IsPublish);
                Assert.IsNotNull(feed.PatientEmail);

            }

            Assert.AreEqual(list.Count, 2);

            Assert.IsNotNull(objectResult);

            //Assert.IsInstanceOfType(result, typeof(OkResult)); 
            //proverava instancu znaci da li je result tipa okResult, provera da li je taj rezultat dobar
        }

        [TestMethod]
        public async Task AddPublishFeedbackTest() {

            ProjectConfiguration projectConfiguration = new ProjectConfiguration();
            projectConfiguration.DatabaseConfiguration = new DatabaseConfiguration();
            projectConfiguration.DatabaseConfiguration.ConnectionString = "Server=DESKTOP-HEAPRGO\\SQLEXPRESS;Initial Catalog=psvTest;Trusted_Connection=True";


            FeedbackController controller = new FeedbackController(projectConfiguration);
            IActionResult result = await controller.AddPublishFeedback(1);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            OkObjectResult objectResult = result as OkObjectResult;
            
            bool resultValue = bool.Parse(objectResult.Value.ToString());

            Assert.AreEqual(resultValue, true);

            //Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}
