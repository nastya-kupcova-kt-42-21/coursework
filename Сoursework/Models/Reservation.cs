using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Сoursework.Models
{
    public class Reservation
    {
        [Key]
        public int BookingId { get; set; } //код бронирования

        public int GuestId { get; set; } //код гостя

        public int RoomId { get; set; } //код номера

        public int ServiceId { get; set; } //код услуги

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } //дата заезда

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; } //дата выезда

        [Required]
        [StringLength(100)]
        public string? BookingStatus { get; set; } //статус бронирования

        [ForeignKey("GuestId")]
        public Guest Guests { get; set; } //связь с гостем

        [ForeignKey("RoomId")]
        public Room Rooms { get; set; } //связь с номером

        [ForeignKey("ServiceId")]
        public Service Services { get; set; } //связь с услугой

        public ICollection<Payment> Payments { get; set; } //связь с оплатой
    }
}
