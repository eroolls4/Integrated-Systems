using System.ComponentModel.DataAnnotations;

namespace LAB1.Models
{
    public class Concert
    {

        [Key]
        public Guid Id { get; set; }


        [Required]
        public string ConcertName { get; set; }
        [Required]
        public string ConcertPlace { get; set; }

        [Required]
        public string ConcertImage { get; set; }

        [Required]
        public DateTime ConcertDate { get; set; }
        [Required]
        public double Price { get; set; }

        public virtual ICollection<Ticket>? Tickets { get; set; }
    }
}
