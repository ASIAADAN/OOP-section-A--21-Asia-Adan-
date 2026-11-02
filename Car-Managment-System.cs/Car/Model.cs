namespace CarManagementSystem.Model
{
    public class Car
    {
        public string CarName;
        public string CarNum;
        public int CarPrice;
        public int CarModel;
        public string CarColour;
        public string CarStatus;

        public Car()
        {
        }

        public Car(string carName, string carNum, int carPrice,
                   int carModel, string carColour, string carStatus)
        {
            CarName = carName;
            CarNum = carNum;
            CarPrice = carPrice;
            CarModel = carModel;
            CarColour = carColour;
            CarStatus = carStatus;
        }

        public override string ToString()
        {
            return $"{CarName},{CarNum},{CarPrice},{CarModel},{CarColour},{CarStatus}";
        }
    }
}