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
    
    public partial class Company_Contact_Persons
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company_Contact_Persons()
        {
            this.Transactions = new HashSet<Transaction>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public int company_id { get; set; }
        public string email { get; set; }
        public string contact { get; set; }
        public Nullable<int> created_by { get; set; }
        public Nullable<int> updated_by { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
        public string photo { get; set; }
        public bool deleted { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
