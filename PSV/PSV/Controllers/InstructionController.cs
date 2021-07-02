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
    public class InstructionController : DefaultController
    {
        InstructionService instructionService = new InstructionService();

        public InstructionController(ProjectConfiguration configuration) : base(configuration)
        {
        }

        public InstructionController() 
        {
        
        }

        [Route("/api/addInstruction")]
        [HttpPost]
        public async Task<IActionResult> addInstruction(Instruction ins)
        {
            return Ok(instructionService.Add(ins, GetCurrentUser()));
        }

        [Route("/api/getAllInstructions")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(instructionService.GetAll());
        }
    }
}
