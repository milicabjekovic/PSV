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
