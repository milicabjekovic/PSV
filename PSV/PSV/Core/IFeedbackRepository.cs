using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Core
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {


        IEnumerable<Feedback> GetAllAdmin();

        IEnumerable<Feedback> GetAllPublished();
        
        
    }

    
}
