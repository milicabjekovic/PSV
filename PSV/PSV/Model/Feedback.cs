using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Model
{
    public class Feedback : Entity
    {
        private string feedback;

        private string patientEmail;

        public string Feed
        {
            get { return feedback; }
            set { feedback = value; }
        }

        public string PatientEmail
        {
            get { return patientEmail; }
            set { patientEmail = value; }
        }
    }
}
