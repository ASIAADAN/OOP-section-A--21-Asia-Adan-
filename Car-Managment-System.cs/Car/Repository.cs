using System;
using System.Collections.Generic;
using System.IO;
using CarManagementSystem.Model;

namespace CarManagementSystem.Repository
{
    public class CarRepository
    {
        private readonly string _filePath = "car.txt";

        private List<Car> _cars = new List<Car>();

        public CarRepository()
        {
            if (File.Exists(_filePath))
            {
                _cars = GetAll();
            }
            else
            {
                _cars.Add(new Car("civic", "ABC123", 5000000, 2022, "Black", "Available"));
                _cars.Add(new Car("audi", "XYZ456", 4500000, 2021, "White", "Booked"));
                _cars.Add(new Car("Mehran", "LMN789", 1500000, 2018, "Silver", "Available"));
                _cars.Add(new Car("City", "DEF321", 4000000, 2020, "brown", "Booked"));
                _cars.Add(new Car("Alto", "GHI654", 3000000, 2023, "green", "Available"));
                _cars.Add(new Car("jeep", "JKL987", 8000000, 2022, "olive", "Available"));

                SaveAll(_cars);
            }
        }

        public void Save(Car car)
        {
            _cars.Add(car);
            SaveAll(_cars);
        }

        public void SaveAll(List<Car> cars)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, false))
            {
                writer.WriteLine(cars.Count);

                foreach (Car car in cars)
                {
                    writer.WriteLine(car.ToString());
                }
            }
        }

        public List<Car> GetAll()
        {
            List<Car> cars = new List<Car>();

            if (!File.Exists(_filePath))
            {
                return cars;
            }

            using (StreamReader reader = new StreamReader(_filePath))
            {
                string countLine = reader.ReadLine();

                if (countLine == null)
                {
                    return cars;
                }

                int count = int.Parse(countLine);

                for (int i = 0; i < count; i++)
                {
                    string line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                      string[] data = line.Split(',');

                       Car car = new Car
                       (

                        data[0],
                        data[1],
                        int.Parse(data[2]),
                        int.Parse(data[3]),
                        data[4],
                        data[5] 
                       );


                    cars.Add(car);
                }
            }

            return cars;
        }

        public bool RemoveByNumber(string carNumber)
        {
            Car car = _cars.Find(c => c.CarNum == carNumber);

            if (car != null)
            {
                _cars.Remove(car);
                SaveAll(_cars);
                return true;
            }

            return false;
        }
        public bool RemoveByName(string carName)
        {
            Car car = _cars.Find(c => c.CarName == carName );
            if (car != null)
            {
                _cars.Remove(car);
                SaveAll(_cars);
                return true;

            }
            return false;
        }
    }
}