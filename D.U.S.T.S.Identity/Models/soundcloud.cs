//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace D.U.S.T.S.Identity.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class soundcloud
    {
        public int artistid { get; set; }
        public Nullable<int> followers { get; set; }
        public int tracks { get; set; }
        public string link { get; set; }
    
        public virtual artistinformation artistinformation { get; set; }
    }
}