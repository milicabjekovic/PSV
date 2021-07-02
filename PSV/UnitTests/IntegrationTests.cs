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
    class IntegrationTests
    {
        [TestMethod]
        public async void GetDrugs()
        {
            IntegrationController controller = new IntegrationController();

            var result = await controller.getDrugs();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async void GetOrderDrugs()
        {
            IntegrationController controller = new IntegrationController();

            var result = await controller.getOrderDrugs();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async void addOrderDrugs()
        {
            IntegrationController controller = new IntegrationController();

            OrderRequest order = new OrderRequest();

            order.DrugId = 1;
            order.Quantity = 1;
            

            var result = await controller.createOrderDrug(order);

            Assert.IsNotNull(result);
        }

    }
}
