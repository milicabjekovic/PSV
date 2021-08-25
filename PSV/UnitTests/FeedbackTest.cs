using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSV.Configuration;
using PSV.Controllers;
using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public async Task getAllPatinetFeedbacksTestAsync() {

            ProjectConfiguration projectConfiguration = new ProjectConfiguration();
            projectConfiguration.DatabaseConfiguration = new DatabaseConfiguration();
            projectConfiguration.DatabaseConfiguration.ConnectionString = "Server=DESKTOP-HEAPRGO\\SQLEXPRESS;Initial Catalog=psvTest;Trusted_Connection=True";

            FeedbackController controller = new FeedbackController(projectConfiguration);
            IActionResult result = await controller.getAllPatinetFeedbacks();
            Assert.IsInstanceOfType(result, typeof(OkResult)); 
            //proverava instancu znaci da li je result tipa okResult, provera da li je taj rezultat dobar
        }

        [TestMethod]
        public async Task AddPublishFeedbackTest() {

            ProjectConfiguration projectConfiguration = new ProjectConfiguration();
            projectConfiguration.DatabaseConfiguration = new DatabaseConfiguration();
            projectConfiguration.DatabaseConfiguration.ConnectionString = "Server=DESKTOP-HEAPRGO\\SQLEXPRESS;Initial Catalog=psvTest;Trusted_Connection=True";


            FeedbackController controller = new FeedbackController(projectConfiguration);
            IActionResult result = await controller.AddPublishFeedback(1);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}
