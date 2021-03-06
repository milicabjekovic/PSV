using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Model
{
    public class BusinessHours : Entity
    {
		
		private DateTime startTime;

		private DateTime endTime;

        private int day;

        private User doctor;

        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        public User Doctor
        {
            get { return doctor; }
            set { doctor = value; }
        }

        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        public int Day
        {
            get { return day; }
            set { day = value; }
        }

    }
}
