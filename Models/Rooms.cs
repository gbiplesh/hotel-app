namespace HotelApp.Models
{
    public class Rooms
    {
        public int Id { get; set; }
        public string RoomType { get; set; } = " ";
        public int Price { get; set; }
        public int Available { get; set; }

        public Rooms()
        {
        }

    }
}
