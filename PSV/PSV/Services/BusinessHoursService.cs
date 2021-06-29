using PSV.Model;
using PSV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Services
{
    public class BusinessHoursService
    {
        public IEnumerable<BusinessHours> GetAll()
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    return unitOfWork.BusinessHours.GetAll();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Add(BusinessHours business)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
                {
                    BusinessHours newHour = new BusinessHours();

                    newHour.StartTime = business.StartTime.AddHours(2);
                    newHour.EndTime = business.EndTime.AddHours(2);
                    newHour.Day = business.Day;

                    unitOfWork.BusinessHours.Add(newHour);
                    unitOfWork.Complete();

                    unitOfWork.BusinessHours.Update(newHour);
                    User user = unitOfWork.Users.Get(business.Doctor.Id);
                    newHour.Doctor = user;

                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        //da li doktor radi ili ne
        public bool CheckDoctorBusinessHour(User userDoctor, DateTime date) {

            using (UnitOfWork unitOfWork = new UnitOfWork(new PSVContext()))
            {
                List<BusinessHours> listHours = unitOfWork.BusinessHours.GetBusinessHoursByDoctor(userDoctor.Id);

                foreach( BusinessHours hours in listHours ) {

                    if ((date.Hour >= hours.StartTime.Hour - 2)
                        && ((int)date.DayOfWeek == hours.Day)
                        && (date.Hour < hours.EndTime.Hour - 2) && hours.Doctor != null && hours.Doctor.Id == userDoctor.Id) {
                        return true;
                    }
                }
                
            }

            return false;
        }

    }
}
