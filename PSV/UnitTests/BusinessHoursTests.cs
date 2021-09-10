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
    public class BusinessHoursTests
    {

        [TestMethod]
        public async Task GetBusinessHours()
        {

            ProjectConfiguration projectConfiguration = new ProjectConfiguration();
            projectConfiguration.DatabaseConfiguration = new DatabaseConfiguration();
            projectConfiguration.DatabaseConfiguration.ConnectionString = "Server=DESKTOP-HEAPRGO\\SQLEXPRESS;Initial Catalog=psvTest;Trusted_Connection=True";

            BusinessHoursController controller = new BusinessHoursController();

            IActionResult result = await controller.GetAll();

            OkObjectResult objectResult = result as OkObjectResult;

            List<BusinessHours> list = objectResult.Value as List<BusinessHours>;
           
            foreach (BusinessHours buss in list)
            {

                Assert.IsNotNull(buss.Day);
                
                Assert.IsFalse(buss.Deleted);
                Assert.IsNotNull(buss.EndTime);
                Assert.IsNotNull(buss.StartTime);
               

            }
            //tu bi jos se dodalo za svaki da se proverava
            DateTime startTime = new DateTime(2021, 06, 29, 06, 0, 0);
            DateTime endTime = new DateTime(2021, 06, 29, 19, 30, 0);
            
            list[0].StartTime.Date.Equals(startTime.Date);
            list[0].StartTime.Hour.Equals(startTime.Hour);
            list[0].EndTime.Date.Equals(endTime.Date);
            list[0].EndTime.Hour.Equals(endTime.Hour);
            list[0].EndTime.Minute.Equals(endTime.Minute);
            list[0].Day.Equals(2);

            DateTime startTime1 = new DateTime(2021, 06, 29, 6, 0, 0);
            DateTime endTime1 = new DateTime(2021, 06, 29, 18, 0, 0);
            list[1].StartTime.Date.Equals(startTime1.Date);
            list[1].StartTime.Hour.Equals(startTime1.Hour);
            list[1].EndTime.Date.Equals(endTime1.Date);
            list[1].EndTime.Hour.Equals(endTime1.Hour);
            list[1].Day.Equals(2);

            DateTime startTime2 = new DateTime(2021, 06, 29, 8, 30, 0);
            DateTime endTime2 = new DateTime(2021, 06, 29, 16, 0, 0);
            list[2].StartTime.Date.Equals(startTime2.Date);
            list[2].StartTime.Hour.Equals(startTime2.Hour);
            list[2].EndTime.Date.Equals(endTime2.Date);
            list[2].EndTime.Hour.Equals(endTime2.Hour);
            list[2].Day.Equals(3);

            DateTime startTime3 = new DateTime(2021, 06, 28, 8, 30, 0);
            DateTime endTime3 = new DateTime(2021, 06, 28, 17, 0, 0);
            list[3].StartTime.Date.Equals(startTime3.Date);
            list[3].StartTime.Hour.Equals(startTime3.Hour);
            list[3].EndTime.Date.Equals(endTime3.Date);
            list[3].EndTime.Hour.Equals(endTime3.Hour);
            list[3].Day.Equals(1);


        }

        [TestMethod]
        public async Task AddBusinessHoursAsync()
        {
            ProjectConfiguration projectConfiguration = new ProjectConfiguration();
            projectConfiguration.DatabaseConfiguration = new DatabaseConfiguration();
            projectConfiguration.DatabaseConfiguration.ConnectionString = "Server=DESKTOP-HEAPRGO\\SQLEXPRESS;Initial Catalog=psvTest;Trusted_Connection=True";

            BusinessHoursController controller = new BusinessHoursController();

            BusinessHours business = new BusinessHours();
            business.Day = 2;

            User doctor = new User();
            doctor.Id = 4;

            business.Doctor = doctor;
            DateTime startTime = new DateTime(2021, 06, 28, 6, 0, 0);
            DateTime endTime = new DateTime(2021, 06, 28, 9, 0, 0);
            business.StartTime = startTime;
            business.EndTime = endTime;
            business.Deleted = false;

            IActionResult result = await controller.Add(business);

            OkObjectResult objectResult = result as OkObjectResult;

            bool resultValue = bool.Parse(objectResult.Value.ToString());

            Assert.AreEqual(resultValue, true);

        }
    }
}
