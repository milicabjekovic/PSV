using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void GetBusinessHours()
        {
            BusinessHoursController controller = new BusinessHoursController();

            var result = controller.GetAll();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddBusinessHours()
        {
            BusinessHoursController controller = new BusinessHoursController();

            BusinessHours business = new BusinessHours();

            business.Day = 1;
            business.Deleted = false;
            User doc = new User();
            doc.UserType = UserType.Doctor;
            business.Doctor = doc;
            
            var result = controller.Add(business);

            Assert.IsNotNull(result);
        }
    }
}
