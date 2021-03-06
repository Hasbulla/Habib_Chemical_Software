﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Habib_Chemical_Software
{
    public partial class ProductMetaData
    {
        [Display(Name = "Id")]
        public int id { get; set; }

        [Required(ErrorMessage = "Please Provide Product Name")]
        [Display(Name = "Product Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please Select a Category")]
        [Display(Name = "Category")]
        public int category_id { get; set; }
        
        [Display(Name = "Country")]
        public string country { get; set; }
        
        [Display(Name = "Company")]
        public string company { get; set; }

        [Required(ErrorMessage = "Please Select Product Type")]
        [Display(Name = "Product Type")]
        public string product_type { get; set; }

        [Required(ErrorMessage = "Please Select Weight Type")]
        [Display(Name = "Weight Type")]
        public int weight_type { get; set; }

        [Required(ErrorMessage = "Please Provide Weight in Single Bag/Drum/Barrel")]
        [Display(Name = "Weight Per Unit")]
        public int weight_per_bag { get; set; }
        
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string description { get; set; }

        [Range(0, UInt64.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [Display(Name = "Current Amount")]
        public int current_amount { get; set; }

        [FileType("jpg,jpeg,png")]
        public IEnumerable<HttpPostedFileBase> file { get; set; }

        //[RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Only Image files allowed.")]
        [Display(Name = "Photo")]
        public string photo { get; set; }
    }

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
        public IEnumerable<HttpPostedFileBase> file { get; set; }
    }
}