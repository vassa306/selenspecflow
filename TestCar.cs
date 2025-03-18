using System;
using System.Collections.Generic;
using System.Linq;
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

        static void Main(string[] args)
        {
            Car car = new Car(1, "Model1", "Make1", 2021, "Red");
            Console.WriteLine(car.ToString());


        }
    }
}
