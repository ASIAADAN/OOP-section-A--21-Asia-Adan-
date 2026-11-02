using System;
using System.Collections.Generic;
using CarManagementSystem.Model;
using CarManagementSystem.Service;

namespace CarManagementSystem.UI
{



    public class CarUI
    {
        private readonly CarService _service;

        public CarUI()
        {
            _service = new CarService();
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("|----------------------------------------------------------------------------------------------------------------------------------|");
                Console.WriteLine("|---------------------------------------------------|               ---....................__                                   |");
                Console.WriteLine("|---------------------------------------------------|           '  _'.]]_  .'-._               ___                                 |");
                Console.WriteLine("|       LIFE IS TOO SHORT TO DRIVE BORING CARS      |          __..                                                                |");
                Console.WriteLine("|---------------------------------------------------| _____.-'        (_) |       ]]            ]]'-.                              |");
                Console.WriteLine("|            PREMIUM CAR BOOKING SYSTEM             |//_      ___________'___________]]_....... ...]]__'..'____ -.                 |");
                Console.WriteLine("|---------------------------------------------------||  T      ___      Xxxx|x...       |               ___           -._          |");
                Console.WriteLine("|                1. Admin                           ||  |  _'     '_    xxxx|xxxxxxx==  |             -'   '-          |           |");
                Console.WriteLine("|                2. Customer                        |]- J // //    ))   XXXX|XXXXXX++   |            //      ) )           |__     |");
                Console.WriteLine("|                3. Exit                            |  -| |  | //--| |   xxx|'.    |                 | |(__) |  |            /     |");
                Console.WriteLine("|---------------------------------------------------||__)||  | (__//   _____|________   |___________ ||      |  |------------      |");
                Console.WriteLine("|               Choose your option:                 |     \\     //.'// ------------------------------((     ////-----------       |");
                Console.WriteLine("|---------------------------------------------------|      .'.__.'.                                    .'.--.'.                    |");
                Console.WriteLine("|----------------------------------------------------------------------------------------------------------------------------------|");
               
                string option = Console.ReadLine();

                if (option == "1")
                {
                    AdminLogin();
                }
                else if (option == "2")
                {
                    CustomerMenu();
                }
                else if (option == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong option.");
                }
            }
        }

        private void AdminLogin()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();

                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                if (username == "1234" && password == "admin")
                {
                    Console.WriteLine("Login successful.");
                    AdminMenu();
                    return;
                }

                Console.WriteLine("Wrong username or password.");
            }
        }

        private void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("\nADMIN MENU");
                Console.WriteLine("1. Add car");
                Console.WriteLine("2. View total sales");
                Console.WriteLine("3. View all cars");
                Console.WriteLine("4. Total revenue");
                Console.WriteLine("5. Search by price");
                Console.WriteLine("6. Logout");
                Console.Write("Choose option: ");

                string option = Console.ReadLine();

                if (option == "1")
                {
                    AddCarInput();
                }
                else if (option == "2")
                {
                    Console.WriteLine("Total sales: "
                        + _service.TotalSalesCount);
                }
                else if (option == "3")
                {
                    DisplayCars(_service.GetAllCars());
                }
                else if (option == "4")
                {
                    Console.WriteLine("Total revenue: Rs. "
                        + _service.TotalRevenue);
                }
                else if (option == "5")
                {
                    Console.Write("Enter car price: ");

                    int price = int.Parse(Console.ReadLine());

                    if (price > 0)
                    {
                        DisplayCars(_service.SearchByPrice(price));
                    }
                    else
                    {
                        Console.WriteLine("Invalid price.");
                    }
                }
                else if (option == "6")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong option.");
                }
            }
        }

        private void AddCarInput()
        {
            Console.Write("Enter car name: ");
            string name = Console.ReadLine();

            Console.Write("Enter car number: ");
            string number = Console.ReadLine();

            Console.Write("Enter car price: ");
            int price = int.Parse(Console.ReadLine());
          

            Console.Write("Enter car model/year: ");
            int model = int.Parse(Console.ReadLine());

            Console.Write("Enter car colour: ");
            string colour = Console.ReadLine();

            Console.Write("Enter car status: ");
            string status = Console.ReadLine();

            Car car = new Car(name, number, price, model, colour, status);

            _service.AddCar(car);

            Console.WriteLine("Car added successfully.");
        }

        private void CustomerMenu()
        {
            while (true)
            {
                Console.WriteLine("\nCUSTOMER MENU");
                Console.WriteLine("1. View all cars");
                Console.WriteLine("2. Book a test drive");
                Console.WriteLine("3. Search car by name");
                Console.WriteLine("4. Search car by model");
                Console.WriteLine("5. Book a car");
                Console.WriteLine("6. Exit");
                Console.Write("Choose option: ");

                string option = Console.ReadLine(); `

                if (option == "1")
                {
                    DisplayCars(_service.GetAllCars());
                }
                else if (option == "2")
                {
                    TestDriveInput();
                }
                else if (option == "3")
                {
                    Console.Write("Enter car name: ");
                    string name = Console.ReadLine();

                    DisplayCars(_service.SearchByName(name));
                }
                else if (option == "4")
                {
                    Console.Write("Enter car model/year: ");
                   
                }
                else if (option == "5")
                {
                    Console.Write("Enter car name to book: ");
                    string name = Console.ReadLine();

                    if (_service.BookCar(name))
                    {
                        Console.WriteLine("Car booked successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Car not available or not found.");
                    }
                }
                else if (option == "6")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong option.");
                }
            }
        }

        private void TestDriveInput()
        {
            Console.Write("Enter your name: ");
            string customerName = Console.ReadLine();

            Console.Write("Enter your location: ");
            string location = Console.ReadLine();

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your phone number: ");
            string phone = Console.ReadLine();

            Console.Write("Enter car name: ");
            string carName = Console.ReadLine();

            List<Car> cars = _service.SearchByName(carName);

            if (cars.Count > 0)
            {
                Console.WriteLine("Thank you, " + customerName + ".");
                Console.WriteLine("Test drive request received for " + carName);
                Console.WriteLine("Location: " + location);
                Console.WriteLine("Email: " + email);
                Console.WriteLine("Phone: " + phone);
            }
            else
            {
                Console.WriteLine("Car not found.");
            }
        }

        private void DisplayCars(List<Car> cars)
        {
            if (cars.Count == 0)
            {
                Console.WriteLine("No cars found.");
                return;
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(
                    $"Name: {car.CarName}, " +
                    $"Number: {car.CarNum}, " +
                    $"Price: {car.CarPrice}, " +
                    $"Model: {car.CarModel}, " +
                    $"Colour: {car.CarColour}, " +
                    $"Status: {car.CarStatus}");
            }
        }


      
    }
}
 
