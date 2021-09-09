using Microsoft.EntityFrameworkCore;
using PSV.Core;
using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Repository
{
    public class InstructionRepository : Repository<Instruction>, IInstructionRepository
    {
        public InstructionRepository(DbContext context) : base(context)
        {

        }

        public Instruction GetInstruction(int patientId, string specialization, int doctorId)
        {
            return PsvContext.Instructions.Where(x => x.Patient.Id == patientId && x.Specialization == specialization && !x.IsUsed && x.Doctor.Id == doctorId).FirstOrDefault();
        }
    }
}
