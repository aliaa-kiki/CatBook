using CatBook.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace catbook.Models
{
    public class cat
    {
        public int id { get; set; }
        public string name { get; set; }
        public string photo { get; set; }
        public string about { get; set; }
        public string userId { get; set; }
        public string status { get; set; }
        public string vaccinated { get; set; }
        public string neutered { get; set; }
        public int vaccinationbook { get; set;}

        public virtual ICollection<catTrait> catTtraits { get; set; }
        public virtual ICollection<request> receivedRequests { get; set; }
        [ForeignKey("userId")]
        public virtual CatBookUser CatBookUser { get; set; }

        public cat()
        {

        }
    }
}
