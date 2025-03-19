using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Testcar
    {
        public void TestMethod()
        {

            Console.WriteLine("Inside Test Method...");

        }

        public static void Main(string[] args)
        {
            Car car = new Car(1, "Camry", "Toyota", 2020, "Red");
            bool highTemp = false;
            bool lowTemp = false;
            Random random = new Random();
            int num = random.Next(0, 100);

            switch (num)
            {
                case int n when n < 10:
                    highTemp = false;
                    lowTemp = true;
                    break;

                case int n when n > 10 && n < 20:
                    highTemp = false;
                    lowTemp = false;
                    break;

                case int n when n > 70 && n < 100:
                    highTemp = true;
                    lowTemp = false;
                    break;

                default:
                    highTemp = false;
                    lowTemp = false;
                    break;
            }

            Console.WriteLine($"Temperature: {num}, HighTemp: {highTemp}, LowTemp: {lowTemp}");

            try
            {
                if (highTemp)
                {
                    throw new Exception("High Temperature, Car not starting...");
                }
                else if (lowTemp)
                {
                    throw new Exception("Low Temperature, Car not starting...");
                }

                car.Start();
                car.Accelerate();
                car.Brake();
                car.shift();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
               
            }
        }
    }

}
