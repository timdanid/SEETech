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
    
    public partial class PracticeTypeThreshold
    {
        public int ID { get; set; }
        public int PracticeTypeID { get; set; }
        public int Minimum { get; set; }
        public int Average { get; set; }
        public int Maximum { get; set; }
    
        public virtual PracticeType PracticeType { get; set; }
    }
}
