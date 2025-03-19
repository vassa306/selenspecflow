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
            bool highTemp = false;
            
            Car car = new Car(1, "Charger", "Dodge", 2015, "Black");
            Console.WriteLine(car.ToString());
            int i = 0;
            int j = 5;

            Random random = new Random();
            int num = random.Next(i, j);
            highTemp = num > 5 ? true : false;
            Console.WriteLine(num + " " + highTemp);

            Console.WriteLine("i = " + i + " j = " + j);

                
                if (!highTemp){ car.TurnKey(); car.Start(); car.shift(); car.Accelerate(); }
                else
                {
                    Console.WriteLine("Car start failed");

                }
            }
        }
    }
