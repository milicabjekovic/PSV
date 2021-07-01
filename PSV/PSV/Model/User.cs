using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Model
{
    public class User : Entity
    {
        private int id;

        private string email;

        private string firstName;

        private string lastName;

        private string address;

        private string city;

        private string country;

        private string phoneNumber;

        private string password;

        private UserType userType;

        private User choosenDoctor;

        private string specialization;

        private bool isFirstTime;

        public string Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }

        public bool IsFirstTime
        {
            get { return isFirstTime; }
            set { isFirstTime = value; }
        }

        public User ChoosenDoctor
        {
            get { return choosenDoctor; }
            set { choosenDoctor = value; }
        }


        public UserType UserType 
        {
            get { return userType; }
            set { userType = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string FirstName 
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string LastName
        {
            get { return lastName ; }
            set { lastName = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
    }
}
