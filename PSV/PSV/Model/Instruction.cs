using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Model
{
    public class Instruction : Entity
    {

        private User doctor;

        private string specialization;

        private bool isUsed;

        private User patient;

        public User Doctor
        {
            get { return doctor; }
            set { doctor = value; }
        }

        public string Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }

        public bool IsUsed
        {
            get { return isUsed; }
            set { isUsed = value; }
        }

        public User Patient
        {
            get { return patient; }
            set { patient = value; }
        }


    }
}
