using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PSV.Core;
using PSV.Model;
using PSV.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class UnitFeedbackTest
    {
        FeedbackService service = new(CreateStubRepository(), CreateMockUserService());

        [Fact]
        public void GetAllAppReviews()
        {
            List<Feedback> feedbacks = (List<Feedback>)service.GetAll();
            Assert.IsNotNull(feedbacks);
        }
        /*
        [Fact]
        public void GetAllPublishedAppReviews()
        {

            List<AppReviewDTO> publishedAppReviews = service.GetAllPublishedAppReviewDTOs();
            publishedAppReviews.Count.ShouldBe(1);
        }

        [Fact]
        public void PublishAppReview()
        {
            AppReview appReview = service.FindAppReviewByID(1);
            service.ChangePublicityOfAppReview(1);
            Assert.True(appReview.Published == true);
        }
        */
        private static UserService CreateMockUserService()
        {
            var mockService = new Mock<UserService>();
            mockService.Setup(repo => repo.GetUserWithEmail(It.IsAny<String>())).Returns(new PSV.Model.User());
            return mockService.Object;
        }


        private static IFeedbackRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IFeedbackRepository>();
            var feedbacks = new List<Feedback>();


            Feedback feed1 = new Feedback();
            feed1.Id = 1;
            feed1.Feed = "Random_Text1";
            feed1.IsPublish = false;
            feed1.Deleted = false;
            feed1.PatientEmail = "milicabjekovic@gmail.com";
            feedbacks.Add(feed1);

            Feedback feed2 = new Feedback();
            feed2.Id = 2;
            feed2.Feed = "Random_Text2";
            feed2.IsPublish = true;
            feed2.Deleted = false;
            feed2.PatientEmail = "marko@gmail.com";
            feedbacks.Add(feed2);

            Feedback feed3 = new Feedback();
            feed3.Id = 3;
            feed3.Feed = "Random_Text3";
            feed3.IsPublish = true;
            feed3.Deleted = true;
            feed3.PatientEmail = "andjela@gmail.com";
            feedbacks.Add(feed3);

            stubRepository.Setup(repo => repo.GetAll()).Returns(feedbacks);
            stubRepository.Setup(repo => repo.GetAllPublished()).Returns(feedbacks.Where((Feedback feed) => feed.IsPublish == true).ToList());
            //stubRepository.Setup(repo => repo.GetUserById(It.IsAny<int>())).Returns(new User { Id = 1, IsPublish = false }).Verifiable();
            //stubRepository.Setup(repo => repo.Save(It.IsAny<Feedback>())).Verifiable();


            return stubRepository.Object;

        }

    }
}
