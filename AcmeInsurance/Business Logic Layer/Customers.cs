using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeInsurance.Business_Logic_Layer
{
    class Customers
    {
        // Declaring properties of a customer
        private int customerID, postCode;
        private string category, firstName, lastName, address, suburb, state, gender, birthDate;
        //private DateTime birthDate;

        // Set-Get properties
        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Suburb
        {
            get { return suburb; }
            set { suburb = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public int PostCode
        {
            get { return postCode; }
            set { postCode = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        // Declaring default constructor
        public Customers() { }

        // Declaring parameterised constructor
        public Customers(int customerid, string firstname,
                         string lastname, string category,
                         string address, string suburb, 
                         string state, int postcode,
                         string gender, string birthdate)
        {
            CustomerID = customerid;
            FirstName = firstname;
            LastName = lastname;
            Category = category;
            Address = address;
            Suburb = suburb;
            State = state;
            PostCode = postcode;
            Gender = gender;
            BirthDate = birthdate;
        }
    }
}
