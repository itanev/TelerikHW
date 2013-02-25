using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    //apply only for structs, classes, interfaces, enums and methods
    [AttributeUsage( AttributeTargets.Struct |
                     AttributeTargets.Class |
                     AttributeTargets.Interface |
                     AttributeTargets.Enum |
                     AttributeTargets.Method )]
    public class VersionAttribute : Attribute
    {
        private double ver;

        public VersionAttribute(double ver)
        {
            this.Version = ver;
        }

        public double Version
        {
            get
            {
                return this.ver;
            }
            set
            {
                this.ver = value;
            }
        }
    }
}
