using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Model
{
    public class Examination : Entity
    {
        private DateTime date;

        private TimeSpan duration;

        private string patientEmail;

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

        public TimeSpan Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public string PatientEmail
        {
            get { return patientEmail; }
            set { patientEmail = value; }
        }

        
    }
}
