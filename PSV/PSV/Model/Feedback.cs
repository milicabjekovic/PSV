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

        private bool isPublish;

        public Feedback(string feedback, string email, bool isPublish) 
        {
            this.feedback = feedback;
            this.patientEmail = email;
            this.isPublish = isPublish;
        }

        public Feedback() { }
        

        public string Feed
        {
            get { return feedback; }
            set { feedback = value; }
        }

        public bool IsPublish
        {
            get { return isPublish; }
            set { isPublish = value; }
        }

        public string PatientEmail
        {
            get { return patientEmail; }
            set { patientEmail = value; }
        }
    }
}
