namespace FinalProjectAPI.Models
{
    public class StadiumLocation
    {
        public StadiumLocation(string location_english, string location_hebrew)
        {
            this.location_english = location_english;
            this.location_hebrew = location_hebrew;
        }

        public string location_english { get; set; }
        public string location_hebrew{ get; set; }
        public StadiumLocation()
        {

        }
    }

}
