using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Сoursework.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; } //код услуги

        [Required]
        [StringLength(100)]
        public string? Name { get; set; } //название

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; } //стоимость

        [Required]
        [StringLength(100)]
        public string? Description { get; set; } //описание

        public ICollection<Reservation> Reservations { get; set; } // связь с бронированием
    }
}
