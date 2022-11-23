using CatBook.Areas.Identity.Data;

namespace catbook.Models
{
    public class request
    {
        public int id { get; set; }
        public CatBookUser fromUser { get; set; }
        public CatBookUser toUser { get; set; }
        public string message { get; set; }
        public string contact { get; set; }
        public string status { get; set; }
    }
}
