using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Core
{
    public interface IInstructionRepository : IRepository<Instruction>
    {

        Instruction GetInstruction(int patientId, string specialization, int doctorId);
    }

    
}
