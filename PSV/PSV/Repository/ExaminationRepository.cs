using Microsoft.EntityFrameworkCore;
using PSV.Core;
using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Repository
{
    public class ExaminationRepository : Repository<Examination>, IExaminationRepository
    {
        public ExaminationRepository(DbContext context) : base(context)
        {

        }

        public override IEnumerable<Examination> GetAll()
        {
            return PsvContext.Examinations.Include(x => x.Doctor).Where(x => x.Deleted == false).ToList();
        }

        public  IEnumerable<Examination> GetPatientExam(string email)
        {
            return PsvContext.Examinations.Include(x => x.Doctor).Where(x => x.Deleted == true && x.PatientEmail == email && x.Date > DateTime.Now.AddDays(-30)).ToList();
        }


    }
}
