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
    
    public partial class Monthly_Bill
    {
        public int id { get; set; }
        public System.DateTime date { get; set; }
        public int monthly_bill_id { get; set; }
        public string description { get; set; }
        public int amount { get; set; }
        public System.DateTime payment_date { get; set; }
        public Nullable<int> created_by { get; set; }
        public Nullable<int> updated_by { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
        public bool deleted { get; set; }
    
        public virtual Monthly_Bill_Name Monthly_Bill_Name { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}