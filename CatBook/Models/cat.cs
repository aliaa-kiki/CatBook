using CatBook.Areas.Identity.Data;

namespace catbook.Models
{
    public class cat
    {
        public int id { get; set; }
        public string name { get; set; }
        public string photo { get; set; }
        public string about { get; set; }
        public CatBookUser originalUser { get; set; }
        public string status { get; set; }
        public string vaccinated { get; set; }
        public string neutered { get; set; }
        public int vaccinationbook { get; set;}
        public CatBookUser newUser { get; set;}

        public cat()
        {

        }
    }
}
