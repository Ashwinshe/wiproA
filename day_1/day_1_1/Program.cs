using System;

class Program
{
    static void Main(string[] args)
    {
        const int parkingCapacity = 5; // total parking slots
        string[] parkingLot = new string[parkingCapacity];

        // Initialize parking spots
        for (int i = 0; i < parkingLot.Length; i++)
            parkingLot[i] = "Empty";

        Console.WriteLine("Parking lot initialized with " + parkingCapacity + " spots.");

        while (true)
        {
            Console.WriteLine("\n--- Car Parking System ---");
            Console.WriteLine("1. Park Vehicle");
            Console.WriteLine("2. Exit Vehicle");
            Console.WriteLine("3. Show Parking Lot");
            Console.WriteLine("4. Exit Application");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ParkVehicle(parkingLot);
                    break;
                case "2":
                    ExitVehicle(parkingLot);
                    break;
                case "3":
                    ShowParkingLot(parkingLot);
                    break;
                case "4":
                    return; // exit application
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }

    static void ParkVehicle(string[] parkingLot)
    {
        Console.Write("Enter vehicle type (Car/Bike/Truck): ");
        string vehicleType = Console.ReadLine();

        for (int i = 0; i < parkingLot.Length; i++)
        {
            if (parkingLot[i] == "Empty")
            {
                parkingLot[i] = vehicleType;
                Console.WriteLine(vehicleType + " parked at spot " + (i + 1));
                return;
            }
        }
        Console.WriteLine("Parking Full! Cannot park vehicle.");
    }

    static void ExitVehicle(string[] parkingLot)
    {
        Console.Write("Enter spot number to exit vehicle: ");
        if (int.TryParse(Console.ReadLine(), out int spot))
        {
            if (spot > 0 && spot <= parkingLot.Length && parkingLot[spot - 1] != "Empty")
            {
                string vehicleType = parkingLot[spot - 1];
                parkingLot[spot - 1] = "Empty";
                Console.WriteLine(vehicleType + " exited from spot " + spot);
                CalculateCharges(vehicleType);
            }
            else
            {
                Console.WriteLine("Invalid spot or already empty!");
            }
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }
    }

    static void CalculateCharges(string vehicleType)
    {
        int charge = vehicleType.ToLower() switch
        {
            "car" => 50,
            "bike" => 20,
            "truck" => 100,
            _ => 0
        };

        Console.WriteLine("Parking charges for " + vehicleType + ": $" + charge);
    }

    static void ShowParkingLot(string[] parkingLot)
    {
        Console.WriteLine("\nParking Lot Status:");
        for (int i = 0; i < parkingLot.Length; i++)
        {
            Console.WriteLine("Spot " + (i + 1) + ": " + parkingLot[i]);
        }
    }
}
