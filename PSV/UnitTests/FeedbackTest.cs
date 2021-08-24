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
    public class FeedbackTest
    {

        [TestMethod]
        public void WriteUserFeedback()
        {
            FeedbackController controller = new FeedbackController(new PSV.Configuration.ProjectConfiguration());

            Feedback feedback = new Feedback();
            feedback.Deleted = false;
            feedback.Feed = "Test";
            feedback.IsPublish = false;
            feedback.PatientEmail = "test@gmail.com";

            var result = controller.Add(feedback);


            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReadAdminFeedback()
        {
            FeedbackController controller = new FeedbackController(new PSV.Configuration.ProjectConfiguration());

            

            var result = controller.GetAllAdminFeedbacks();


            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReadPatientFeedback()
        {
            FeedbackController controller = new FeedbackController(new PSV.Configuration.ProjectConfiguration());



            var result = controller.getAllPatinetFeedbacks();


            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShareUserFeedbackByAdmin()
        {
            FeedbackController controller = new FeedbackController(new PSV.Configuration.ProjectConfiguration());

            Feedback feedback = new Feedback();
            feedback.Deleted = false;
            feedback.Feed = "Test";
            feedback.IsPublish = true;
            feedback.PatientEmail = "test@gmail.com";

            var result = controller.AddPublishFeedback(feedback.Id);


            Assert.IsNotNull(result);
        }
    }
}
