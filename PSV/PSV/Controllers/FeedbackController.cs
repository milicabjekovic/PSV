using Microsoft.AspNetCore.Mvc;
using PSV.Configuration;
using PSV.Model;
using PSV.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedbackController : DefaultController
    {

        public FeedbackService feedbackService = new FeedbackService();

        public FeedbackController(ProjectConfiguration configuration) : base(configuration)
        {
        }

        [Route("/api/feedbacks/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(feedbackService.Get(id));
        }

        [Route("/api/feedbacks")]
        [HttpGet]
        public async Task<IActionResult> GetAll(int id)
        {
            return Ok(feedbackService.GetAll());
        }

        [Route("/api/feedbacks")]
        [HttpPost]
        public async Task<IActionResult> Add(Feedback feed)
        {
            return Ok(feedbackService.Add(feed, GetCurrentUser()));
        }

        [Route("/api/feedbacks/{id}")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, Feedback feed)
        {
            return Ok(feedbackService.Edit(id, feed));
        }

        [Route("/api/feedbacks/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(feedbackService.Delete(id));
        }

        [Route("/api/getAllPatinetFeedbacks")]
        [HttpGet]
        public async Task<IActionResult> getAllPatinetFeedbacks()
        {
            return Ok(feedbackService.getAllPatinetFeedbacks(GetCurrentUser()));
        }
    }
}
