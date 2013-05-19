using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class PCCreator : Creator<PC>
    {
        private string productName;

        public PCCreator(string productName)
        {
            this.ProductName = productName;
        }

        public string ProductName
        {
            get
            {
                return this.productName;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Product name can not be null!");
                }

                this.productName = value;
            }
        }

        public override PC Create()
        {
            return new PC(this.productName);
        }
    }
}
