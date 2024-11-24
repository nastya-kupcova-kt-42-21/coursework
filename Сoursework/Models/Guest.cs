using System.ComponentModel.DataAnnotations;

namespace Сoursework.Models
{
    public class Guest
    {
        [Key]
        public int GuestId { get; set; } //код гостя

        [Required]
        [StringLength(100)]
        public string? Surname { get; set; } //фамилия

        [Required]
        [StringLength(100)]
        public string? Name { get; set; } //имя

        [Required]
        [StringLength(100)]
        public string? Middlename { get; set; } //отчество

        [Required]
        [StringLength(100)]
        public string? Email { get; set; } //почта

        [Required]
        [StringLength(100)]
        public string? Phone { get; set; } //телефон

        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; } //дата рождения

        public ICollection<Reservation> Reservations { get; set; } // связь с бронированием

        public ICollection<Review> Reviews { get; set; } // связь с оплатой
    }
}
