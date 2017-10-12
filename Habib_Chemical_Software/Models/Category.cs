using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Habib_Chemical_Software
{
    public partial class CategoryMetaData
    {
        [Required(ErrorMessage = "Plaese Provide Category Name")]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }

    [MetadataType(typeof(CategoryMetaData))]
    public partial class Category
    {
    }
}