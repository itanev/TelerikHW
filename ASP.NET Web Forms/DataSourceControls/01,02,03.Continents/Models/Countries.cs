//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _01.Continents.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Countries
    {
        public Countries()
        {
            this.Towns = new HashSet<Towns>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string language { get; set; }
        public Nullable<int> population { get; set; }
        public Nullable<int> continentId { get; set; }
    
        public virtual Continents Continents { get; set; }
        public virtual ICollection<Towns> Towns { get; set; }
    }
}
