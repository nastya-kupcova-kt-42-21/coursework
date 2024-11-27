using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Сoursework.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; } //код оплаты

        public int BookingId { get; set; } //код бронирования

        [NotMapped] // Указываем, что это свойство не должно сохраняться в базе данных
        public decimal Amount => CalculateAmount(); // Вычисляемая сумма

        [Required]
        [StringLength(100)]
        public string? PaymentMethod { get; set; } //способ оплаты

        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; } //дата оплаты

        [ForeignKey("BookingId")]
        public Reservation Reservations { get; set; } // связь с бронированием

        //[NotMapped] // Указываем, что это свойство не должно сохраняться в базе данных
        //public decimal Amount => CalculateAmount(); // Вычисляемая сумма

        private decimal CalculateAmount()
        {
            decimal roomPrice = Reservations?.Rooms?.PriceForNight ?? 0; // Получаем цену за ночь
            decimal servicesTotal = Reservations?.Services?.Price ?? 0; // Сумма всех цен на услуги
            return roomPrice + servicesTotal; // Общая сумма
        }
    }
}
