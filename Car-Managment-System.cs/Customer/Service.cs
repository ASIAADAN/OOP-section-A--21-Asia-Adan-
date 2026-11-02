using System.Collections.Generic;
using CarManagementSystem.Model;
using CarManagementSystem.Repository;

namespace CarManagementSystem.Service
{
    public class CustomerService
    {
        private CustomerRepository _customerRepository =
            new CustomerRepository();

        private CarService _carService;

        public CustomerService(CarService carService)
        {
            _carService = carService;
        }

        public void RegisterCustomer(Customer customer)
        {
            _customerRepository.Save(customer);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }

        public List<Car> ViewAvailableCars()
        {
            return _carService.GetAvailableCars();
        }

        public List<Car> SearchByName(string name)
        {
            return _carService.SearchByName(name);
        }

        public List<Car> SearchByModel(int model)
        {
            return _carService.SearchByModel(model);
        }

        public bool BookCar(string carNumber)
        {
            return _carService.BookCar(carNumber);
        }

        public bool RequestTestDrive(string carNumber)
        {
            List<Car> cars = _carService.GetAvailableCars();

            foreach (Car car in cars)
            {
                if (car.CarNum == carNumber)
                {
                    return true;
                }
            }

            return false;
        }
    }
}