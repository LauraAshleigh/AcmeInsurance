using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeInsurance.Business_Logic_Layer
{
    class Sales
    {
        // Declaring properties of a sale
        private int saleID;
        private string customer, product, payable, startDate;

        // Set-Get properties
        public int SaleID
        {
            get { return saleID; }
            set { saleID = value; }
        }

        public string Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        public string Product
        {
            get { return product; }
            set { product = value; }
        }

        public string Payable
        {
            get { return payable; }
            set { payable = value; }
        }

        public string StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        
        // Declaring default constructor
        public Sales() { }

        // Declaring parameterised constructor
        public Sales(int saleid, string customer, string product, 
                    string payable, string startdate)
        {
            SaleID = saleid;
            Customer = customer;
            Product = product;
            Payable = payable;
            StartDate = startdate;
        }
    }
}
