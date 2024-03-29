﻿using CatBook.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace catbook.Models
{
    public class cat
    {
        public int id { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Gender")]
        public genders gender { get; set; } 
        public string photo { get; set; }
        [Display(Name = "About")]
        public string about { get; set; }
        public string? userId { get; set; }
        public statusStates status { get; set; }
        [Display(Name = "vaccinated")]
        public vaccinationStates vaccinated { get; set; }
        [Display(Name = "Neutered")]
        public Boolean neutered { get; set; }
        [Display(Name = "Vaccination book")]
        public Boolean vaccinationbook { get; set;}

        public virtual ICollection<catTrait>? catTtraits { get; set; }
        public virtual ICollection<request>? receivedRequests { get; set; } 
        [ForeignKey("userId")]
        [Display(Name = "Cat owner")]
        public virtual CatBookUser? CatBookUser { get; set; }

        public cat()
        {

        }
    }

    public enum vaccinationStates 
    {
        [Display(Name = "Fully vaccinated")]
        completed =1,
        [Display(Name = "Incomplete vaccinations")]
        incomplete =2,
        [Display(Name = "Not vaccinated")] 
        none =3
    }

    public enum statusStates 
    {
        [Display(Name = "For adoption")]
        available =1,
        [Display(Name = "Adopted")] 
        adopted =2,
        [Display(Name = "Removed")]
        removed =3
    }

    public enum genders
    {
        Male = 1,
        Female = 2
    }
}
