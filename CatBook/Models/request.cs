using CatBook.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace catbook.Models
{
    public class request
    {
        public int id { get; set; }
        public string senderUserId { get; set; }
        public int? catId { get; set; }
        [Display(Name = "Message")]
        public string message { get; set; }
        [Display(Name = "Contact Method")]
        public string contact { get; set; }
        [ForeignKey("senderUserId")]
        [Display(Name = "Sender")]
        public virtual CatBookUser? senderUser { get; set; }
        [Display(Name = "Cat")]
        public virtual cat? requestedCat { get; set; }

        public request()
        {

        }
    }
}
