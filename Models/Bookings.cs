using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace HotelApp.Models
{
    public class Bookings
    {
        [BindNever]
        public int Id { get; set; }
        [BindRequired]
        public string? RoomType { get; set; }
        public string? FullName { get; set; }
        public int RoomQuantity { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CheckIn { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CheckOut { get; set; }
        public int Price { get; set; }


        public Bookings()
        {
        }

        public Bookings(string? roomType, string? fullName, int roomQuantity, DateTime checkIn, DateTime checkOut, int price)
        {
            RoomType = roomType;
            FullName = fullName;
            RoomQuantity = roomQuantity;
            CheckIn = checkIn;
            CheckOut = checkOut;
            Price = price;
        }   
    }
}
