//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mark
    {
        public Mark()
        {
            this.Students = new HashSet<Student>();
        }
    
        public int id { get; set; }
        public string subject { get; set; }
        public string value { get; set; }
    
        public virtual ICollection<Student> Students { get; set; }
    }
}
