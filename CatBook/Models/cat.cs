using CatBook.Areas.Identity.Data;
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
        [Display(Name = "Has vaccination book")]
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
        completed =1,
        incomplete =2,
        none =3
    }

    public enum statusStates 
    {
        available =1,
        adopted =2,
        removed =3
    }

    public enum genders
    {
        Male = 1,
        Female = 2
    }
}
