//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NuevoStaj.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Managers
    {
        public Managers()
        {
            this.Department_Arragenments = new HashSet<Department_Arragenments>();
        }
    
        public int Manager_ID { get; set; }
        public Nullable<int> Employee_ID { get; set; }
    
        public virtual ICollection<Department_Arragenments> Department_Arragenments { get; set; }
        public virtual Employees Employees { get; set; }
    }
}