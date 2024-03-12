using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LAB1.Models
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }


        [Required]
        public Guid ConcertId { get; set; }

        [ForeignKey("ConcertId")]
        public virtual Concert Concert { get; set; }

        [Required]
        public int NumberOfPeople { get; set; }


        public virtual UserModel? BoughtBy { get; set; }

    
    }
}
