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

                    newExam.Date = exam.Date;
                    newExam.Duration = exam.Duration;

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
    }
}
