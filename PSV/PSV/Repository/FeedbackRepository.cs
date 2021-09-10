using Microsoft.EntityFrameworkCore;
using PSV.Core;
using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Repository
{
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(DbContext context) : base(context)
        {

        }

        

        public  IEnumerable<Feedback> GetAllPublished()
        {
            return PsvContext.Feedback.Where(x => x.IsPublish == true && x.Deleted==false).ToList();
        }

        public IEnumerable<Feedback> GetAllAdmin ()
        {
            return PsvContext.Feedback.Where(x => x.Deleted == false).ToList();
        }

        public IEnumerable<Feedback> GetAllNotPublishedAndDeleted()
        {
            return PsvContext.Feedback.Where(x => x.IsPublish == false && x.Deleted==false).ToList();
        }

        public Feedback GetFeedbackById(int id)
        {
            //proveri moze li tako
            return PsvContext.Feedback.Include(x => x.Id).Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
