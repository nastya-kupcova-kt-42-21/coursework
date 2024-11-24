using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Сoursework.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; } //код оплаты

        public int BookingId { get; set; } //код бронирования

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; } //сумма

        [Required]
        [StringLength(100)]
        public string? PaymentMethod { get; set; } //способ оплаты

        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; } //дата оплаты

        [ForeignKey("BookingId")]
        public Reservation Reservations { get; set; } // связь с бронированием
    }
}
