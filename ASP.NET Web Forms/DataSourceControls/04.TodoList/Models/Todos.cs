//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _04.TodoList.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Todos
    {
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public Nullable<System.DateTime> lastChange { get; set; }
        public Nullable<int> catId { get; set; }
    
        public virtual Categories Categories { get; set; }
    }
}
