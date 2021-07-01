using PSV.Configuration;
using PSV.Controllers;
using PSV.Model;
using PSV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Services
{
    public class ExaminationService
    {
        public BusinessHoursService businessService = new BusinessHoursService();

        public UserService userService = new UserService();

        public Examination Get(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    return unitOfWork.Examinations.Get(id);
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return null;
        }

        public IEnumerable<Examination> GetAll()
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    return unitOfWork.Examinations.GetAll();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

       public bool Add(Examination exam)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    Examination newExam = new Examination();

                    newExam.Date = exam.Date.AddHours(2);
                    newExam.Duration = exam.Duration;
                    newExam.PatientEmail = exam.PatientEmail;

                    unitOfWork.Examinations.Add(newExam);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool Edit(int id, Examination exam)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    Examination examDB = Get(id);

                    unitOfWork.Examinations.Update(examDB);

                    examDB.Date = exam.Date;
                    examDB.Duration = exam.Duration;
                    examDB.PatientEmail = exam.PatientEmail;

                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    Examination exams = Get(id);

                    if (DateTime.Now > exams.Date.AddHours(-48)) { 
                        
                        return false;
                    }

                    unitOfWork.Examinations.Update(exams);
                    exams.Deleted = true;
                    unitOfWork.Complete();


                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public List<RecommendedExamination> ScheduleExamination(ExaminationRequest exam, User user) {

            List<RecommendedExamination> listRecommended = new List<RecommendedExamination>();

            try
            {
                    bool isWorking = businessService.CheckDoctorBusinessHour(exam.Doctor, exam.Date);

                    bool examExist = ExaminationExist(exam.Doctor, exam.Date.AddHours(2));

                    if (isWorking && !examExist)
                    {
                        RecommendedExamination recExam = new RecommendedExamination();

                        recExam.Date = exam.Date.AddHours(2);
                        recExam.Doctor = exam.Doctor;

                        //AddExam(exam, user);

                        listRecommended.Add(recExam);
                    }
                    else
                    {
                        if (exam.Priority == "Doctor")
                        {
                            for (int i = -7; i <= 7; i++)
                            {
                                DateTime compareDate = new DateTime(exam.Date.Year, exam.Date.Month, exam.Date.Day, 7, 0, 0);
                                compareDate.AddDays(i);

                                for (int j = 1; j <= 20; j++)
                                {
                                    compareDate = compareDate.AddMinutes(30);

                                    isWorking = businessService.CheckDoctorBusinessHour(exam.Doctor, compareDate);

                                    examExist = ExaminationExist(exam.Doctor, compareDate);


                                if (isWorking && !examExist)
                                    {

                                    RecommendedExamination recExam = new RecommendedExamination();

                                    recExam.Date = compareDate;
                                    recExam.Doctor = exam.Doctor;

                                    //AddExam(exam, user);
                                    listRecommended.Add(recExam);
                                }
                                }
                            }
                        }
                        else
                        {
                            IEnumerable<User> doctors = userService.GetAllDoctors();

                            foreach (User doc in doctors)
                            {

                                isWorking = businessService.CheckDoctorBusinessHour(doc, exam.Date);

                                examExist = ExaminationExist(doc, exam.Date.AddHours(2));

                                if (isWorking && !examExist)
                                {
                                    RecommendedExamination recExam = new RecommendedExamination();

                                    recExam.Date = exam.Date.AddHours(2);
                                    recExam.Doctor = doc;

                                    //AddExam(exam, user);
                                   listRecommended.Add(recExam);
                                }
                            }
                        }
                    }
                
               return listRecommended;
            }
            catch (Exception e) 
            {
                return null;
            }

            return listRecommended;
        }

        public bool AddExam(ExaminationRequest exam, User user)
        {
            try
            {

                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    Examination newExam = new Examination();

                    newExam.Date = exam.Date;
                    TimeSpan duration = new TimeSpan(0, 30, 0);
                    newExam.Duration = duration;
                    newExam.PatientEmail = user.Email;

                    unitOfWork.Examinations.Add(newExam);
                    unitOfWork.Complete();

                    unitOfWork.Examinations.Update(newExam);
                    newExam.Doctor = exam.Doctor;
                    unitOfWork.Complete();

                    return true;
                }
            }
            catch (Exception e) { }

            return false;
        }

        //da li u tom terminu postoji vec neki pregled ili ne
        public bool ExaminationExist(User userDoctor, DateTime date) {

            using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
            {
                IEnumerable<Examination> listExam = unitOfWork.Examinations.GetAll();

                foreach (Examination exam in listExam) {

                    if (exam.Doctor != null && exam.Doctor.Id == userDoctor.Id &&
                        exam.Date.Day == date.Day && exam.Date.Month == date.Month && exam.Date.Hour == date.Hour ) {
                        
                        return true;
                    }

                }

            }

            return false;
        }

        public List<Examination> getAllPatientExamination(User user) {

            List<Examination> list = new List<Examination>();
            IEnumerable<Examination> listExaminations = GetAll();

            foreach (Examination exam in listExaminations) {

                if (exam.PatientEmail == user.Email) {
                    if (exam.Deleted==false) {
                        list.Add(exam);
                    }
                    
                }
            }

            return list;
        }
    }
}
