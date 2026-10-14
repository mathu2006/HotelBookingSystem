using HotelBookingSystem;
using HotelBookingSystem.Models;
using System;

namespace HotelBookingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Room[] rooms =
            {
                new Room(101, "Standard", 1500m),
                new Room(102, "Standard", 1500m),
                new Room(201, "Premium", 3000m),
                new Room(202, "Premium", 3000m),
                new Room(301, "Premium", 4000m)
            };

            int choice = 0;

            while (choice != 6)
            {
                Console.WriteLine("\n===== HOTEL ROOM MANAGEMENT =====");
                Console.WriteLine("1. View All Rooms");
                Console.WriteLine("2. Search Room by Number");
                Console.WriteLine("3. Search Rooms by Type");
                Console.WriteLine("4. Sort Rooms by Price");
                Console.WriteLine("5. Search Room by Price");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please enter a valid number.");
                    choice = 0;
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        DisplayAllRooms(rooms);
                        break;

                    case 2:
                        SearchRoom(rooms);
                        break;

                    case 3:
                        SearchByType(rooms);
                        break;

                    case 4:
                        SortRoomByPrice(rooms);
                        break;

                    case 5:
                        SearchRoomByPrice(rooms);
                        break;

                    case 6:
                        Console.WriteLine("Thank you!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void DisplayAllRooms(Room[] rooms)
        {
            foreach (Room room in rooms)
            {
                room.DisplayRoom();
            }
        }

        static void SearchRoom(Room[] rooms)
        {
            Console.Write("Enter room number: ");

            if (!int.TryParse(Console.ReadLine(), out int roomNumber))
            {
                Console.WriteLine("Invalid room number.");
                return;
            }

            foreach (Room room in rooms)
            {
                if (room.RoomNumber == roomNumber)
                {
                    room.DisplayRoom();
                    return;
                }
            }

            Console.WriteLine("Room not found.");
        }

        static void SearchByType(Room[] rooms)
        {
            Console.Write("Enter room type (Standard/Premium): ");
            string type = Console.ReadLine() ?? "";

            bool found = false;

            foreach (Room room in rooms)
            {
                if (room.RoomType.Equals(
                    type, StringComparison.OrdinalIgnoreCase))
                {
                    room.DisplayRoom();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No rooms found for this type.");
            }
        }

        static void SortRoomByPrice(Room[] rooms)
        {
            for (int i = 0; i < rooms.Length - 1; i++)
            {
                for (int j = i + 1; j < rooms.Length; j++)
                {
                    if (rooms[i].NightlyRate > rooms[j].NightlyRate)
                    {
                        Room temp = rooms[i];
                        rooms[i] = rooms[j];
                        rooms[j] = temp;
                    }
                }
            }

            Console.WriteLine("\nRooms sorted by price:");

            foreach (Room room in rooms)
            {
                room.DisplayRoom();
            }
        }

        static void SearchRoomByPrice(Room[] rooms)
        {
            Console.Write("Enter room price: ");

            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Invalid price.");
                return;
            }

            bool found = false;

            foreach (Room room in rooms)
            {
                if (room.NightlyRate == price)
                {
                    room.DisplayRoom();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No rooms found at this price.");
            }
        }
    }
}

