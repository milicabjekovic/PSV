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
    class FeedbackTest
    {

        [TestMethod]
        public async void WriteUserFeedback()
        {
            FeedbackController controller = new FeedbackController();

            Feedback feedback = new Feedback();
            feedback.Deleted = false;
            feedback.Feed = "Test";
            feedback.IsPublish = false;
            feedback.PatientEmail = "test@gmail.com";

            var result = await controller.Add(feedback);


            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async void ReadAdminFeedback()
        {
            FeedbackController controller = new FeedbackController();

            

            var result = await controller.GetAllAdminFeedbacks();


            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async void ReadPatientFeedback()
        {
            FeedbackController controller = new FeedbackController();



            var result = await controller.getAllPatinetFeedbacks();


            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async void ShareUserFeedbackByAdmin()
        {
            FeedbackController controller = new FeedbackController();

            Feedback feedback = new Feedback();
            feedback.Deleted = false;
            feedback.Feed = "Test";
            feedback.IsPublish = true;
            feedback.PatientEmail = "test@gmail.com";

            var result = await controller.AddPublishFeedback(feedback.Id);


            Assert.IsNotNull(result);
        }
    }
}
