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
    class ExaminationTest
    {

        [TestMethod]
        public async void UserScheduleExamination()
        {
            ExaminationController controller = new ExaminationController();

            ExaminationRequest exam = new ExaminationRequest();
           
            exam.Deleted = false;
            exam.Doctor = null;
            
            exam.PatientEmail = "test@gmail.com";
            exam.Priority = "";
            

            var result = await controller.ScheduleExamination(exam);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async void UserAddExamination()
        {
            ExaminationController controller = new ExaminationController();

            ExaminationRequest exam = new ExaminationRequest();

            exam.Deleted = false;
            exam.Doctor = null;

            exam.PatientEmail = "test@gmail.com";
            exam.Priority = "";


            var result = await controller.AddExamination(exam);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task UserCancelExaminationAsync()
        {
            ExaminationController controller = new ExaminationController();

            Examination exam = new Examination();

            exam.Id = 1;


            var result = await controller.Delete(exam.Id);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async void UserAddInstructionExamination()
        {
            InstructionController controller = new InstructionController();

            Instruction ins = new Instruction();

            ins.IsUsed = false;
            ins.Specialization = "neka";
            User doc = new User();
            doc.UserType = UserType.Doctor;
            ins.Doctor = doc;
            User pat = new User();
            pat.UserType = UserType.Patient;
            ins.Patient = pat;


            var result = await controller.addInstruction(ins);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public async void UserExaminationHistory()
        {
            ExaminationController controller = new ExaminationController();

            var result = await controller.getAllPatinetExamination();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async void UserToxicPatinet()
        {
            ExaminationController controller = new ExaminationController();

            var result = await controller.GetToxicPatients();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async void BlockToxicUser()
        {
            ExaminationController controller = new ExaminationController();

            Examination exam = new Examination();

            exam.Id = 1;

            var result = await controller.BlockToxicUser(exam.Id);

            Assert.IsNotNull(result);
        }
    }
}
