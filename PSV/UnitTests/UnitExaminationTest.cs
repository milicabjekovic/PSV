using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSV.Model;
using PSV.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class UnitExaminationTest
    {
        [TestMethod]
        public void ExaminationNotExistTest()
        {
            ExaminationService service = new ExaminationService();

            User doctor = new User();
            doctor.Email = "doktor@gmail.com";
            doctor.Id = 17;
            doctor.Specialization = "opsta praksa";


            bool result = service.ExaminationExist(doctor, DateTime.Now);

            //nema zakazanog pregleda u tom terminu
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void ExaminationExistTest()
        {
            ExaminationService service = new ExaminationService();

            User doctor = new User();
            doctor.Email = "doktor@gmail.com";
            doctor.Id = 17;
            doctor.Specialization = "opsta praksa";

            //hour,min,sec
            DateTime time = new DateTime(2021, 08, 31, 11, 0, 0);

            bool result = service.ExaminationExist(doctor, time);

            //nema zakazanog pregleda u tom terminu
            Assert.IsTrue(result);

        }

        //kada radi u to vreeme
        [TestMethod]
        public void CheckDoctorBusinessHourTest()
        {
            BusinessHoursService service = new BusinessHoursService();

            User doctor = new User();
            doctor.Email = "doktor@gmail.com";
            doctor.Id = 17;
            doctor.Specialization = "opsta praksa";

            //hour,min,sec
            //06.09.2021. je ponedeljak, taj dan radi od 8:30-17:00
            DateTime time = new DateTime(2021, 09, 06, 11, 0, 0);

            bool isWorking = service.CheckDoctorBusinessHour(doctor, time);

            //radi tada
            Assert.IsTrue(isWorking);

        }

        //kada ne radi u to vreeme
        [TestMethod]
        public void CheckDoctorBusinessHourNotWorkingTest()
        {
            BusinessHoursService service = new BusinessHoursService();

            User doctor = new User();
            doctor.Email = "doktor@gmail.com";
            doctor.Id = 17;
            doctor.Specialization = "opsta praksa";

            //hour,min,sec
            //07.09.2021. je utorak, taj dan ne radi
            DateTime time = new DateTime(2021, 09, 07, 11, 0, 0);

            bool isWorking = service.CheckDoctorBusinessHour(doctor, time);

            //ne radi tada
            Assert.IsFalse(isWorking);

        }

        //ova 4 prva testa prolaze  i dobro rade
        [TestMethod] //provera je l ima instrukciju za nekog ko nije opste prakse, i ovde treba da ima insturkciju
        public void CheckDoctorInstructionSpecializationTest()
        {
            ExaminationService service = new ExaminationService();

            ExaminationRequest exam = new ExaminationRequest();
            User doctor = new User();
            doctor.Specialization = "kardiolog";
            doctor.Id = 10;

            exam.Doctor = doctor;

            User patient = new User();
            patient.Id = 9;
            //doctor 10, kardilog je , pacijent 9 ima instrukciju
            bool checkDoctorSpec = service.CheckDoctorSpecialization(exam, patient);
            //ima instrukciju
            Assert.IsTrue(checkDoctorSpec);

        }

        [TestMethod] //provera je l ima instrukciju za nekog ko nije opste prakse, i ovde treba da ima insturkciju
        public void CheckDoctorNotInstructionSpecializationTest()
        {
            ExaminationService service = new ExaminationService();

            ExaminationRequest exam = new ExaminationRequest();
            User user = new User();

            User doctor = new User();
            doctor.Specialization = "kardiolog";
            doctor.Id = 2;

            exam.Doctor = doctor;

            User patient = new User();
            patient.Id = 14;

            bool checkDoctorSpec = service.CheckDoctorSpecialization(exam, patient);

            Assert.IsFalse(checkDoctorSpec);

        }

        [TestMethod] //provera za prioritet - doktor
        public void CheckDoctorPriorityTest()
        {
            ExaminationService service = new ExaminationService();

            ExaminationRequest exam = new ExaminationRequest();
            exam.Priority = "Doctor";

            User doctor = new User();
            //doctor.Id = 17;
            doctor.Id = 10;
            exam.Doctor = doctor;
            //kardiolog
            DateTime dateTime = new DateTime(2021, 09, 08, 7, 30, 0);
            exam.Date = dateTime;

            User patient = new User();
            patient.Id = 9;


            List<RecommendedExamination> lista = service.CheckPriority(exam, patient);

            Assert.AreEqual(lista.Count, 195);

        }

        [TestMethod] //provera za prioritet - datum
        public void CheckDatePriorityTest()
        {
            ExaminationService service = new ExaminationService();

            ExaminationRequest exam = new ExaminationRequest();
            exam.Priority = "Date";

            User doctor = new User();
            //doctor.Id = 17;
            doctor.Id = 10;
            exam.Doctor = doctor;
            //kardiolog
            DateTime dateTime = new DateTime(2021, 09, 08, 8, 30, 0);
            exam.Date = dateTime;

            User patient = new User();
            patient.Id = 9;


            List<RecommendedExamination> lista = service.CheckPriority(exam, patient);

            lista[0].Date.Day.Equals(8);
            lista[0].Date.Month.Equals(9);
            lista[0].Date.Year.Equals(2021);
            lista[0].Date.Hour.Equals(10);
            lista[0].Date.Minute.Equals(30);

            Assert.AreEqual(lista.Count, 1);

        }

        [TestMethod]
        public void CheckNoDatePriorityTest()
        {
            ExaminationService service = new ExaminationService();

            ExaminationRequest exam = new ExaminationRequest();
            exam.Priority = "Date";

            User doctor = new User();
            //doctor.Id = 17;
            doctor.Id = 10;
            exam.Doctor = doctor;
            //kardiolog, ne radi tada i nema sta da vrati
            DateTime dateTime = new DateTime(2021, 09, 08, 5, 30, 0);
            exam.Date = dateTime;

            User patient = new User();
            patient.Id = 9;


            List<RecommendedExamination> lista = service.CheckPriority(exam, patient);

            Assert.AreEqual(lista.Count, 0);

        }

        [TestMethod]
        public void CheckSpecializationPriorityTest()
        {
            ExaminationService service = new ExaminationService();

            ExaminationRequest examSpec = new ExaminationRequest();
            User doctor = new User();
            doctor.Specialization = "kardiolog";
            doctor.Id = 10;

            examSpec.Doctor = doctor;

            User patient = new User();
            patient.Id = 9;
            //doctor 10, kardilog je , pacijent 9 ima instrukciju
            bool checkDoctorSpec = service.CheckDoctorSpecialization(examSpec, patient);
            
            ExaminationRequest exam = new ExaminationRequest();
            exam.Priority = "Doctor";

            User doctor2 = new User();
            //doctor.Id = 17;
            doctor2.Id = 10;
            exam.Doctor = doctor2;
            //kardiolog
            DateTime dateTime = new DateTime(2021, 09, 08, 8, 30, 0);
            exam.Date = dateTime;

            //User patient2 = new User();
            //patient2.Id = 9;


            List<RecommendedExamination> lista = service.CheckPriority(exam, patient);

            Assert.IsTrue(checkDoctorSpec);
            Assert.AreEqual(lista.Count, 195);

        }

        [TestMethod]
        public void CheckSpecializationDatePriorityTest()
        {
            ExaminationService service = new ExaminationService();

            ExaminationRequest examSpec = new ExaminationRequest();
            User doctor = new User();
            doctor.Specialization = "kardiolog";
            doctor.Id = 10;

            examSpec.Doctor = doctor;

            User patient = new User();
            patient.Id = 9;
            //doctor 10, kardilog je , pacijent 9 ima instrukciju
            bool checkDoctorSpec = service.CheckDoctorSpecialization(examSpec, patient);

            ExaminationRequest exam = new ExaminationRequest();
            exam.Priority = "Date";

            User doctor2 = new User();
            //doctor.Id = 17;
            doctor2.Id = 10;
            exam.Doctor = doctor2;
            //kardiolog
            DateTime dateTime = new DateTime(2021, 09, 08, 8, 30, 0);
            exam.Date = dateTime;

            //User patient2 = new User();
            //patient2.Id = 9;


            List<RecommendedExamination> lista = service.CheckPriority(exam, patient);

            lista[0].Date.Day.Equals(8);
            lista[0].Date.Month.Equals(9);
            lista[0].Date.Year.Equals(2021);
            lista[0].Date.Hour.Equals(10);
            lista[0].Date.Minute.Equals(30);

            Assert.IsTrue(checkDoctorSpec);
            Assert.AreEqual(lista.Count, 1);

        }

        [TestMethod]
        public void CheckExamExistFalseIsWorkingTest()
        {
            BusinessHoursService service = new BusinessHoursService();

            User doctor = new User();
            doctor.Email = "doktor@gmail.com";
            doctor.Id = 17;
            doctor.Specialization = "opsta praksa";

            //hour,min,sec
            //06.09.2021. je ponedeljak, taj dan radi od 8:30-17:00
            DateTime time = new DateTime(2021, 09, 06, 11, 0, 0);

            bool isWorking = service.CheckDoctorBusinessHour(doctor, time);

            ExaminationService service2 = new ExaminationService();

            bool result = service2.ExaminationExist(doctor, DateTime.Now);


            //radi tada
            Assert.IsTrue(isWorking);
            //nema zakazanog pregleda u tom terminu
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void CheckExamExistIsNotWorkingTest()
        {
            BusinessHoursService service = new BusinessHoursService();

            User doctor = new User();
            doctor.Email = "doktor@gmail.com";
            doctor.Id = 17;
            doctor.Specialization = "opsta praksa";

            //hour,min,sec
            //06.09.2021. je ponedeljak, taj dan radi od 8:30-17:00
            DateTime time = new DateTime(2021, 09, 06, 18, 0, 0);

            bool isWorking = service.CheckDoctorBusinessHour(doctor, time);

            ExaminationService service2 = new ExaminationService();

            bool result = service2.ExaminationExist(doctor, DateTime.Now);


            //radi tada
            Assert.IsFalse(isWorking);
            //nema zakazanog pregleda u tom terminu
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void CheckExamExistTrueIsNotWorkingTest()
        {
            BusinessHoursService service = new BusinessHoursService();

            User doctor = new User();
            doctor.Email = "doktor@gmail.com";
            doctor.Id = 17;
            doctor.Specialization = "opsta praksa";

            //hour,min,sec
            //06.09.2021. je ponedeljak, taj dan radi od 8:30-17:00
            DateTime time = new DateTime(2021, 09, 06, 18, 0, 0);

            bool isWorking = service.CheckDoctorBusinessHour(doctor, time);

            ExaminationService service2 = new ExaminationService();

            //tad ima zakazan pregled
            DateTime timeExam = new DateTime(2021, 08, 31, 11, 0, 0);
            bool result = service2.ExaminationExist(doctor, timeExam);


            //radi tada
            Assert.IsFalse(isWorking);
            //nema zakazanog pregleda u tom terminu
            Assert.IsTrue(result);

        }

        // jos dodati kombinaciju neku za interval je l to bas taj i sl 
    }
}
