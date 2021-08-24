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

        public object BlockToxicUser(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    User user = unitOfWork.Users.Get(id);

                    unitOfWork.Users.Update(user);
                    user.IsBlocked = true;
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

                    Instruction ins = unitOfWork.Instructions.GetInstruction(user.Id, exam.Doctor.Specialization);

                    if (ins != null) 
                    {
                        unitOfWork.Instructions.Update(ins);
                        ins.IsUsed = true;
                    }

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

        

        public List<User> getToxicUser()
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {

                    List<User> listPatients = unitOfWork.Users.GetAllPatients();
                    List<User> toxicPatients = new List<User>();

                    foreach (User patient in listPatients)
                    {
                        IEnumerable<Examination> list = unitOfWork.Examinations.GetPatientExam(patient.Email);

                        if (list.Count() >= 3 && patient.IsBlocked==false)
                        {
                            toxicPatients.Add(patient);
                        }
                    }

                    return toxicPatients;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
