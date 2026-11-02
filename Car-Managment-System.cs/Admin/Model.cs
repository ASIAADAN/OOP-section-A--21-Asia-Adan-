namespace CarManagementSystem.Model
{
    public class Admin
    {
        public string Username;
        public string Password;

        public Admin()
        {
        }

        public Admin(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}