using System.ComponentModel.DataAnnotations;

namespace ShamrockHeightsEvents.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public List<string> VolunteerList { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }
        public string Year { get; set; }
        public string Month {  get; set; }
        public string Day { get; set; }
        public string Time { get; set; }

    }
}
