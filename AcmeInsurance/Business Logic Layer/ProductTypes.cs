using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeInsurance.Business_Logic_Layer
{
    class ProductTypes
    {
        // Declaring properties of a product type
        private int productTypeID;
        private string productType;

        // Set-Get properties
        public int ProductTypeID
        {
            get { return productTypeID; }
            set { productTypeID = value; }
        }

        public string ProductType
        {
            get { return productType; }
            set { productType = value; }
        }

        // Declaring default constructor
        public ProductTypes() { }

        // Declaring parameterised constructor
        public ProductTypes(int producttypeid, string producttype)
        {
            ProductTypeID = producttypeid;
            ProductType = producttype;
        }
    }
}
