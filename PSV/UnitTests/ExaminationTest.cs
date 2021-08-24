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
    public class ExaminationTest
    {

        [TestMethod]
        public void UserScheduleExamination()
        {
            ExaminationController controller = new ExaminationController(new PSV.Configuration.ProjectConfiguration());

            ExaminationRequest exam = new ExaminationRequest();
           
            exam.Deleted = false;
            exam.Doctor = null;
            
            exam.PatientEmail = "test@gmail.com";
            exam.Priority = "";
            

            var result = controller.ScheduleExamination(exam);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UserAddExamination()
        {
            ExaminationController controller = new ExaminationController(new PSV.Configuration.ProjectConfiguration());

            ExaminationRequest exam = new ExaminationRequest();

            exam.Deleted = false;
            exam.Doctor = null;

            exam.PatientEmail = "test@gmail.com";
            exam.Priority = "";


            var result = controller.AddExamination(exam);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UserCancelExaminationAsync()
        {
            ExaminationController controller = new ExaminationController(new PSV.Configuration.ProjectConfiguration());

            Examination exam = new Examination();

            exam.Id = 1;


            var result = controller.Delete(exam.Id);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UserAddInstructionExamination()
        {
            InstructionController controller = new InstructionController(new PSV.Configuration.ProjectConfiguration());

            Instruction ins = new Instruction();

            ins.IsUsed = false;
            ins.Specialization = "neka";
            User doc = new User();
            doc.UserType = UserType.Doctor;
            ins.Doctor = doc;
            User pat = new User();
            pat.UserType = UserType.Patient;
            ins.Patient = pat;


            var result = controller.addInstruction(ins);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void UserExaminationHistory()
        {
            ExaminationController controller = new ExaminationController(new PSV.Configuration.ProjectConfiguration());

            var result = controller.getAllPatinetExamination();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UserToxicPatinet()
        {
            ExaminationController controller = new ExaminationController(new PSV.Configuration.ProjectConfiguration());

            var result = controller.GetToxicPatients();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BlockToxicUser()
        {
            ExaminationController controller = new ExaminationController(new PSV.Configuration.ProjectConfiguration());

            Examination exam = new Examination();

            exam.Id = 1;

            var result = controller.BlockToxicUser(exam.Id);

            Assert.IsNotNull(result);
        }
    }
}
