//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hack.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Country
    {
        public Country()
        {
            this.Cities = new HashSet<City>();
            this.Counties = new HashSet<County>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<County> Counties { get; set; }
    }
}
