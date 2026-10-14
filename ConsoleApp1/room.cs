using HotelBookingSystem.Models;
using System;

namespace HotelBookingSystem.Models
{
    public class Room
    {
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public decimal NightlyRate { get; set; }
        public bool IsAvailable { get; set; }

        public Room(int roomNumber, string roomType, decimal nightlyRate)
        {
            this.RoomNumber = roomNumber;
            this.RoomType = roomType;
            this.NightlyRate = nightlyRate;
            this.IsAvailable = true;
        }

        public void DisplayRoom()
        {
            Console.WriteLine(
                $"Room: {RoomNumber} | Type: {RoomType} | " +
                $"Price: ₹{NightlyRate} | " +
                $"Available: {(IsAvailable ? "Yes" : "No")}"
            );
        }
    }
}
