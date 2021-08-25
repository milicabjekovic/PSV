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
    public class ExaminationTest
    {
        [TestMethod]
        public async Task ScheduleExaminationTestAsync() {

            ProjectConfiguration projectConfiguration = new ProjectConfiguration();
            projectConfiguration.DatabaseConfiguration = new DatabaseConfiguration();
            projectConfiguration.DatabaseConfiguration.ConnectionString = "Server=DESKTOP-HEAPRGO\\SQLEXPRESS;Initial Catalog=psvTest;Trusted_Connection=True";

            ExaminationController controller = new ExaminationController(projectConfiguration);
           

            ExaminationRequest req = new ExaminationRequest();
            req.Date = new DateTime(2010, 1, 1, 8, 0, 15);
            req.Deleted = false;
            User doc = new User();
            doc.Address = "adresa";
            doc.City = "NS";
            req.Doctor = doc;
            req.Duration = new TimeSpan(1,2,3);
            req.PatientEmail = "peric@gmail.com";
            req.Priority = "neki";

            IActionResult result = await controller.ScheduleExamination(req);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public async Task getAllPatinetExaminationTestAsync() {

            ProjectConfiguration projectConfiguration = new ProjectConfiguration();
            projectConfiguration.DatabaseConfiguration = new DatabaseConfiguration();
            projectConfiguration.DatabaseConfiguration.ConnectionString = "Server=DESKTOP-HEAPRGO\\SQLEXPRESS;Initial Catalog=psvTest;Trusted_Connection=True";

            ExaminationController controller = new ExaminationController(projectConfiguration);
            IActionResult result = await controller.getAllPatinetExamination();
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }


}

