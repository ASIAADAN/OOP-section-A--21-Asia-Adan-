using System;
using System.Collections.Generic;
using System.IO;
using CarManagementSystem.Model;

namespace CarManagementSystem.Repository
{
    public class CustomerRepository
    {
        private readonly string _filePath = "customers.txt";

        public void Save(Customer customer)
        {
            List<Customer> customers = GetAll();

            customers.Add(customer);

            SaveAll(customers);
        }

        public void SaveAll(List<Customer> customers)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, false))
            {
                writer.WriteLine(customers.Count);

                foreach (Customer customer in customers)
                {
                    writer.WriteLine(customer.ToString());
                }
            }
        }

        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();

            if (!File.Exists(_filePath))
            {
                return customers;
            }

            using (StreamReader reader = new StreamReader(_filePath))
            {
                string countLine = reader.ReadLine();

                if (countLine == null)
                {
                    return customers;
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

                    Customer customer = new Customer(
                        data[0],
                        data[1],
                        data[2],
                        data[3]
                    );

                    customers.Add(customer);
                }
            }

            return customers;
        }
    }
}