﻿using Microsoft.AspNetCore.Mvc;
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
    public class ExaminationController : Controller
    {
        public ExaminationService examService = new ExaminationService();

        [Route("/api/examinations/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(examService.Get(id));
        }

        [Route("/api/examinations")]
        [HttpGet]
        public async Task<IActionResult> GetAll(int id)
        {
            return Ok(examService.GetAll());
        }

        [Route("/api/examinations")]
        [HttpPost]
        public async Task<IActionResult> Add(Examination exam)
        {
            return Ok(examService.Add(exam));
        }

        [Route("/api/examinations/{id}")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, Examination exam)
        {
            return Ok(examService.Edit(id, exam));
        }

        [Route("/api/examinations/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(examService.Delete(id));
        }
    }
}
