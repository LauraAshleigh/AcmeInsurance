using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeInsurance.Business_Logic_Layer
{
    class Categories
    {
        // Declaring properties of a category
        private string category;
        private int categoryID;

        // Set-Get properties
        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        // Declaring default constructor
        public Categories() { }

        // Declaring parameterised constructor
        public Categories(int categoryid, string category)
        {
            CategoryID = categoryid;
            Category = category;
        }
    }
}
