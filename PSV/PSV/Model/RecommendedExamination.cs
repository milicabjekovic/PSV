using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Model
{
    public class RecommendedExamination : Entity
    {

        private DateTime date;

        private User doctor;

        public User Doctor
        {
            get { return doctor; }
            set { doctor = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

    }
}
