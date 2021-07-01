using PSV.Model;
using PSV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Services
{
    public class InstructionService
    {

        public IEnumerable<Instruction> GetAll()
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    return unitOfWork.Instructions.GetAll();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Add(Instruction instruction, User user)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    Instruction newInstruction = new Instruction();

                    newInstruction.Specialization = instruction.Specialization;
                    newInstruction.IsUsed = false;
                    

                    unitOfWork.Instructions.Add(newInstruction);
                    unitOfWork.Complete();

                    unitOfWork.Instructions.Update(newInstruction);
                    User doctor = unitOfWork.Users.Get(user.Id);
                    unitOfWork.Users.Detach(doctor);
                    newInstruction.Doctor = doctor;
                    newInstruction.Patient = instruction.Patient;

                    unitOfWork.Complete();

                   
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }


    }
}
