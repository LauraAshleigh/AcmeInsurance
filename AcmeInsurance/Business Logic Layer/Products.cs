using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeInsurance.Business_Logic_Layer
{
    class Products
    {
        // Declaring properties of a product
        private int productID;
        private string productType, productName;
        private float yearlyPremium;

        // Set-Get properties
        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        public string ProductType
        {
            get { return productType; }
            set { productType = value; }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public float YearlyPremium
        {
            get { return yearlyPremium; }
            set { yearlyPremium = value; }
        }

        // Declaring default constructor
        public Products() { }

        // Declaring parameterised constructor
        public Products(int productid, string producttype,
                         string productname, float yearlypremium)
        {
            ProductID = productid;
            ProductType = producttype;
            ProductName = productname;
            YearlyPremium = yearlypremium;
        }
    }
}
