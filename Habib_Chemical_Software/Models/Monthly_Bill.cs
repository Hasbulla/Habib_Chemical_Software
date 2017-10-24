using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Habib_Chemical_Software
{
    public partial class Monthly_Bill_MetaData
    {
        [Display(Name = "Id")]
        public int id { get; set; }

        [Required(ErrorMessage = "Please Select a Bill Name")]
        [Display(Name = "Bill Name")]
        public int monthly_bill_id { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Required(ErrorMessage = "Please Enter Bill Amount")]
        [Range(0, UInt64.MaxValue, ErrorMessage = "Please Enter Valid Bill Amount")]
        [Display(Name = "Amount")]
        public int amount { get; set; }

        [Required(ErrorMessage = "Please Select Paying Date")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date Paid")]
        public DateTime payment_date { get; set; }
    }

    [MetadataType(typeof(Monthly_Bill_MetaData))]
    public partial class Monthly_Bill
    {
    }
}