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
    
    public partial class Transaction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transaction()
        {
            this.Transaction_Product = new HashSet<Transaction_Product>();
        }
    
        public int id { get; set; }
        public System.DateTime date { get; set; }
        public string type { get; set; }
        public string chalan_number { get; set; }
        public string cash_memo_number { get; set; }
        public Nullable<int> created_by { get; set; }
        public Nullable<int> updated_by { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
        public Nullable<int> contact_person_id { get; set; }
        public Nullable<int> supplier_id { get; set; }
        public string payment_type { get; set; }
        public string check_number { get; set; }
        public Nullable<System.DateTime> check_expire_date { get; set; }
        public string bank_name { get; set; }
        public bool check_cleared { get; set; }
        public int total_money { get; set; }
        public int total_paid { get; set; }
        public int total_due { get; set; }
        public bool deleted { get; set; }
    
        public virtual Company_Contact_Persons Company_Contact_Persons { get; set; }
        public virtual Supplier Supplier { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction_Product> Transaction_Product { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}