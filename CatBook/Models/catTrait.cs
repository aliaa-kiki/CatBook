namespace catbook.Models
{
    public class catTrait
    {
        public int id { get; set; }
        public int catId { get; set; }
        public int traitId { get; set; }

        public virtual cat cat { get; set; }
        public virtual trait trait { get; set; }

        public catTrait()
        {
                
        }
    }
}
