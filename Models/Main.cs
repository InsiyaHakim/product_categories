using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Products_Categories.Models
{
    public class Product
    {
        [Key]
        public int productID{get;set;}

        [Required]
        [Display(Name="Name")]
        public string name{get;set;}

        [Required]
        [Display(Name="Description")]
        public string description{get;set;}

        [Required]
        [Display(Name="Price")]
        public float price{get;set;}

        public DateTime created_at{get;set;} = DateTime.Now;
        public DateTime updated_at{get;set;} = DateTime.Now;

        public List<Association> product_association {get;set;}


    }

    public class Category
    {
        [Key]
        public int categoryID{get;set;}

        [Required]
        [Display(Name="Name")]
        public string name{get;set;}

        public DateTime created_at{get;set;} = DateTime.Now;
        public DateTime updated_at{get;set;} = DateTime.Now;
        public List<Association> category_association {get;set;}

    }

    public class Association
    {
        [Key]
        public int associationID{get;set;}
        public int productID{get;set;}

        [Display(Name="Add Category:")]
        public int categoryID{get;set;}
        public Product product{get;set;}
        public Category category{get;set;}
    }
}