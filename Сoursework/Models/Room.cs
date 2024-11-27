using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Сoursework.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; } //код номера

        public int RommNumber { get; set; } //номер номера

        [Required]
        [StringLength(100)]
        public string? RoomType { get; set; } //тип номера

        public int MaxGuests { get; set; } //макс кол-ство гостей

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PriceForNight { get; set; } //цена за ночь

        [Required]
        [StringLength(100)]
        public string? Availability { get; set; } //доступность

        public ICollection<Reservation> Reservations { get; set; } // связь с бронированием

        public ICollection<Review> Reviews { get; set; }  // связь с оплатой
    }
}
