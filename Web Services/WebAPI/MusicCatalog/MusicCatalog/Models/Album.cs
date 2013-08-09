//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MusicCatalog.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Album
    {
        public Album()
        {
            this.Artists = new HashSet<Artist>();
            this.Songs = new HashSet<Song>();
        }
    
        public int id { get; set; }
        public string title { get; set; }
        public Nullable<int> year { get; set; }
        public string producer { get; set; }
    
        public virtual ICollection<Artist> Artists { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}