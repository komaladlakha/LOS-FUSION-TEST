//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LOSFusionTest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblCar
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public Nullable<System.DateTime> Year { get; set; }
        public string UserId { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
