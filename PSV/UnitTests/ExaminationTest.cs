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
    public class ExaminationTest
    {
        [TestMethod]
        public async Task ScheduleExaminationTestAsync() {

            ProjectConfiguration projectConfiguration = new ProjectConfiguration();
            projectConfiguration.DatabaseConfiguration = new DatabaseConfiguration();
            projectConfiguration.DatabaseConfiguration.ConnectionString = "Server=DESKTOP-HEAPRGO\\SQLEXPRESS;Initial Catalog=psvTest;Trusted_Connection=True";

            ExaminationController controller = new ExaminationController(projectConfiguration);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
                                        new Claim(ClaimTypes.NameIdentifier, "SomeValueHere"),
                                        new Claim("Email", "milicabjekovic@gmail.com")
                                        // other required and custom claims
                                   }, "TestAuthentication"));
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.User = user;
           

            ExaminationRequest req = new ExaminationRequest();
            req.Date = new DateTime(2021, 6, 29, 11, 0, 0);
            req.Deleted = false;
            User doc = new User();
            doc.Address = "adresa";
            doc.City = "NS";
            doc.Email = "baba@gmail.com";
            doc.Specialization = "kardiolog";
            req.Doctor = doc;
            req.Duration = new TimeSpan(0,30,0);
            req.PatientEmail = "milicabjekovic@gmail.com";
            req.Priority = "lekar";
            req.Doctor.Id = 2;

            IActionResult result = await controller.ScheduleExamination(req);

            OkObjectResult objectResult = result as OkObjectResult;

            List<RecommendedExamination> list = objectResult.Value as List<RecommendedExamination>;

            foreach (RecommendedExamination exam in list)
            {
                
                Assert.IsNotNull(exam.Date);
                Assert.IsNotNull(exam.Doctor);
                

            }

            list[0].Date.Day.Equals(29);
            list[0].Date.Month.Equals(6);
            list[0].Date.Year.Equals(2021);
            list[0].Date.Hour.Equals(13);
            

            Assert.AreEqual(list.Count, 1);

            Assert.IsNotNull(objectResult);
        }

        [TestMethod]
        public async Task getAllPatinetExaminationTestAsync() {

            ProjectConfiguration projectConfiguration = new ProjectConfiguration();
            projectConfiguration.DatabaseConfiguration = new DatabaseConfiguration();
            projectConfiguration.DatabaseConfiguration.ConnectionString = "Server=DESKTOP-HEAPRGO\\SQLEXPRESS;Initial Catalog=psvTest;Trusted_Connection=True";

            ExaminationController controller = new ExaminationController(projectConfiguration);


            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
                                        new Claim(ClaimTypes.NameIdentifier, "SomeValueHere"),
                                        new Claim("Email", "milicabjekovic@gmail.com")
                                        // other required and custom claims
                                   }, "TestAuthentication"));
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.User = user;

            IActionResult result = await controller.getAllPatinetExamination();
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            OkObjectResult objectResult = result as OkObjectResult;

            List<Examination> list = objectResult.Value as List<Examination>;

            foreach (Examination exam in list)
            {

                Assert.IsNotNull(exam.Date);
                Assert.IsNotNull(exam.PatientEmail);

            }

            list[0].PatientEmail.Equals("milicabjekovic@gmail.com");
            list[0].Date.Day.Equals(31);
            list[0].Date.Month.Equals(8);
            list[0].Date.Year.Equals(2021);
            list[0].Date.Hour.Equals(11);

            list[1].PatientEmail.Equals("milicabjekovic@gmail.com");
            list[1].Date.Day.Equals(31);
            list[1].Date.Month.Equals(8);
            list[1].Date.Year.Equals(2021);
            list[1].Date.Hour.Equals(12);

            Assert.AreEqual(list.Count, 2);

            Assert.IsNotNull(objectResult);
        }
    }


}

