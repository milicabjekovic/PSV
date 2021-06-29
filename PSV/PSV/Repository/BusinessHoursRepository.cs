using Microsoft.EntityFrameworkCore;
using PSV.Core;
using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Repository
{
    public class BusinessHoursRepository : Repository<BusinessHours>, IBusinessHours
    {

        public BusinessHoursRepository(DbContext context) : base(context)
        {

        }

        public List<BusinessHours> GetBusinessHoursByDoctor(int id)
        {
            return PsvContext.BusinessHours.Include(x => x.Doctor).Where(x => x.Doctor.Id == id).ToList();
        }
    }
}
