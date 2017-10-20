using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Habib_Chemical_Software
{
    public partial class CompanyMetaData
    {
        [Display(Name = "Id")]
        public int id { get; set; }


        [Required(ErrorMessage = "Please Provide Company Name")]
        [Display(Name = "Company Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please Provide An Address")]
        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        public string address { get; set; }


        [Required(ErrorMessage = "Please Provide An Email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }


        [Required(ErrorMessage = "Please Select Company Type")]
        [Display(Name = "Company Type")]
        public string company_type { get; set; }
        

        [Display(Name = "Total Due")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,0}৳")]
        //[DisplayFormat(NullDisplayText = "0", ApplyFormatInEditMode = true, DataFormatString = "{0:BDT}")]
        public int due_amount { get; set; }


        [Display(Name = "Updated By")]
        public virtual Company updated_by { get; set; }


        [Display(Name = "Last Update")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt   dd/MMM/yyyy}")]
        public Nullable<System.DateTime> update_date { get; set; }
    }

    [MetadataType(typeof(CompanyMetaData))]
    public partial class Company
    {
    }
}