using System.Collections.Generic;
using CarManagementSystem.Model;

namespace CarManagementSystem.Service
{
    public class AdminService
    {
        private Admin _admin = new Admin("1234", "admin");

        private CarService _carService;

        public AdminService(CarService carService)
        {
            _carService = carService;
        }

        public bool Login(string username, string password)
        {
            if (_admin.Username == username &&
                _admin.Password == password)
            {
                return true;
            }

            return false;
        }

        public void AddCar(Car car)
        {
            _carService.AddCar(car);
        }

        public List<Car> GetAllCars()
        {
            return _carService.GetAllCars();
        }

        public bool RemoveCar(string carNumber)
        {
            return _carService.RemoveCar(carNumber);
        }

        public int GetTotalSales()
        {
            return _carService.TotalSalesCount;
        }

        public int GetTotalRevenue()
        {
            return _carService.TotalRevenue;
        }

        public List<Car> SearchByPrice(int price)
        {
            return _carService.SearchByPrice(price);
        }
    }
}