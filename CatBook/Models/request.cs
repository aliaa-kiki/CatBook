using CatBook.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace catbook.Models
{
    public class request
    {
        public int id { get; set; }
        public string senderUserId { get; set; }
        public int catId { get; set; }
        public string message { get; set; }
        public string contact { get; set; }
        public string status { get; set; }
        [ForeignKey("senderUserId")]
        public virtual CatBookUser senderUser { get; set; }
        public virtual cat requestedCat { get; set; }

        public request()
        {

        }
    }
}
