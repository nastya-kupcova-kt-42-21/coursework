using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Сoursework.Models
{
    public class Review
    {
        public int ReviewId { get; set; } //код отзыва

        public int GuestId { get; set; } //код гостя

        public int RoomId { get; set; } //код номера

        public int Rating { get; set; } //оценка

        [Required]
        [StringLength(100)]
        public string? Comment { get; set; } //комментарий

        [DataType(DataType.Date)]
        public DateTime ReviewDate { get; set; } //дата отзыва

        [ForeignKey("GuestId")]
        public Guest Guests { get; set; }  //связь с гостем

        [ForeignKey("RoomId")]
        public Room Rooms { get; set; } //связь с номером
    }
}
