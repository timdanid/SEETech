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
    
    public partial class City
    {
        public City()
        {
            this.Practices = new HashSet<Practice>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string POBox { get; set; }
        public int CountyID { get; set; }
        public int CountryID { get; set; }
    
        public virtual County County { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Practice> Practices { get; set; }
    }
}
