using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Habib_Chemical_Software
{

    public partial class UserMetaData
    {
        [Display(Name = "Id")]
        public int id { get; set; }

        [Required(ErrorMessage = "Please Provide User Name")]
        [Display(Name = "User Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please Provide Contact Number")]
        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        public string contact_number { get; set; }

        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        public string address { get; set; }

        [Required(ErrorMessage = "Please Provide An Email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(ErrorMessage = "Please Provide a Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Updated By")]
        public virtual User updated_by { get; set; }

        [Display(Name = "Last Update")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt   dd/MMM/yyyy}")]
        public Nullable<System.DateTime> update_date { get; set; }
    }

    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {
    }
}