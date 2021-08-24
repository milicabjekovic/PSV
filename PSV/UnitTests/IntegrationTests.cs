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
    public class IntegrationTests
    {
        [TestMethod]
        public void GetDrugs()
        {
            IntegrationController controller = new IntegrationController(new PSV.Configuration.ProjectConfiguration());

            var result = controller.getDrugs();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetOrderDrugs()
        {
            IntegrationController controller = new IntegrationController(new PSV.Configuration.ProjectConfiguration());

            var result = controller.getOrderDrugs();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void addOrderDrugs()
        {
            IntegrationController controller = new IntegrationController(new PSV.Configuration.ProjectConfiguration());

            OrderRequest order = new OrderRequest();

            order.DrugId = 1;
            order.Quantity = 1;
            

            var result = controller.createOrderDrug(order);

            Assert.IsNotNull(result);
        }

    }
}
