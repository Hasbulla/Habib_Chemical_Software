//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Habib_Chemical_Software
{
    using System;
    using System.Collections.Generic;
    
    public partial class Monthly_Bill_Name
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Monthly_Bill_Name()
        {
            this.Monthly_Bill = new HashSet<Monthly_Bill>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public bool deleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Monthly_Bill> Monthly_Bill { get; set; }
    }
}