namespace CarManagementSystem.Model
{
    public class Customer
    {
        public string CustomerName;
        public string Location;
        public string Email;
        public string Phone;

        public Customer()
        {
        }

        public Customer(string customerName, string location,
                        string email, string phone)
        {
            CustomerName = customerName;
            Location = location;
            Email = email;
            Phone = phone;
        }

        public override string ToString()
        {
            return $"{CustomerName},{Location},{Email},{Phone}";
        }
    }
}