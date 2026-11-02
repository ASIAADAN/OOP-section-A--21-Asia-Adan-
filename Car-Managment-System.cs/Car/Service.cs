using System.Collections.Generic;
using System.Linq;
using CarManagementSystem.Model;
using CarManagementSystem.Repository;

namespace CarManagementSystem.Service
{
    public class CarService
    {
        private CarRepository _repository = new CarRepository();

        public int TotalSalesCount { get; private set; }

        public int TotalRevenue { get; private set; }

        public void AddCar(Car car)
        {
            _repository.Save(car);
        }

        public List<Car> GetAllCars()
        {
            return _repository.GetAll();
        }

        public List<Car> GetAvailableCars()
        {
            List<Car> availableCars = new List<Car>();

            foreach (Car car in GetAllCars())
            {
                if (car.CarStatus == "Available")
                {
                    availableCars.Add(car);
                }
            }

            return availableCars;
        }

        public List<Car> SearchByName(string name)
        {
            List<Car> result = new List<Car>();

            foreach (Car car in GetAllCars())
            {
                if (car.CarName == name)
                {
                    result.Add(car);
                }
            }

            return result;
        }

        public List<Car> SearchByModel(int model)
        {
            List<Car> result = new List<Car>();

            foreach (Car car in GetAllCars())
            {
                if (car.CarModel == model)
                {
                    result.Add(car);
                }
            }

            return result;
        }

        public List<Car> SearchByPrice(int price)
        {
            List<Car> result = new List<Car>();

            foreach (Car car in GetAllCars())
            {
                if (car.CarPrice == price)
                {
                    result.Add(car);
                }
            }

            return result;
        }

        public bool BookCar(string carNumber)
        {
            List<Car> cars = GetAllCars();

            foreach (Car car in cars)
            {
                if (car.CarNum == carNumber &&
                    car.CarStatus == "Available")
                {
                    car.CarStatus = "Booked";

                    _repository.SaveAll(cars);

                    TotalSalesCount++;
                    TotalRevenue += car.CarPrice;

                    return true;
                }
            }

            return false;
        }

        public bool RemoveCar(string carNumber)
        {
            return _repository.RemoveByNumber(carNumber);
        }
        public bool RemoveCarByName(string carName) 
        {
            return _repository.RemoveByName(carName);
        }

    }
}