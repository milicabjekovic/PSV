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

                    unitOfWork.Examinations.Remove(exams);


                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool ScheduleExamination(ExaminationRequest exam, User user) {

            try
            {

                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext())) 
                {

                    bool isWorking = businessService.CheckDoctorBusinessHour(exam.Doctor, exam.Date);

                    bool examExist = ExaminationExist(exam.Doctor, exam.Date);

                    if (isWorking && !examExist) {

                        Examination newExam = new Examination();

                        newExam.Date = exam.Date;
                        TimeSpan duration = new TimeSpan(0,30,0);
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

               return false;
            }
            catch (Exception e) 
            {
                return false;
            }
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
    }
}
