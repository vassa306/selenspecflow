using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;
using MongoDB.Driver.Core.Configuration;

namespace test
{
    class Testcar
    {
        public void TestMethod()
        {

            Console.WriteLine("Inside Test Method...");

        }

        public List<Car> generateCarList()
        {
            List<Car> cars = new List<Car>();
            cars.Add(new Car(1, "Model 3", "Tesla", 2021, "Red", CarType.Coupe));
            cars.Add(new Car(2, "Model S", "Tesla", 2021, "Blue", CarType.Coupe));
            cars.Add(new Car(3, "Model X", "Tesla", 2021, "Black", CarType.Coupe));
            cars.Add(new Car(4, "Model Y", "Tesla", 2021, "White", CarType.Hatchback));
            cars.Add(new Car(5, "Cybertruck", "Tesla", 2021, "Silver", CarType.Truck));
            cars.Add(new Car(6, "Roadster", "Tesla", 2021, "Green", CarType.Roadster));
            cars.Add(new Car(7, "840i", "BMW", 2021, "Yellow", CarType.Limo));

            return cars;
        }

        public void starCar(Car car, int lowTemp, bool highTemp)

        {

            while (highTemp)
            {
                Console.WriteLine("Waiting for the engine to cool down...");
                System.Threading.Thread.Sleep(1000);
                highTemp = false;

            }
            car.Start();
        }

     



        public static void Main(string[] args)
        {
            string projectRoot = AppContext.BaseDirectory;
            string envPath = Path.Combine(projectRoot, "..", "..", "..", ".env");

            // Normalizuj cestu (Windows-style)
            envPath = Path.GetFullPath(envPath);
            Env.Load(envPath);
            string connectionString = Env.GetString("MONGO_CONNECTION_STRING");
            string dbName = Env.GetString("MONGO_DB_NAME");
            string collectionName = Env.GetString("MONGO_COLLECTION_NAME");
            
            

            var carService = new CarService(connectionString, dbName, collectionName);


            Testcar testcar = new Testcar();
            List<Car> carList = testcar.generateCarList();
       
            Random random = new Random();
            int temp = random.Next(20, 100);

            if (carList.Count > 0)
            {
                foreach (Car car in carList)
                {
                    if (carService.CarExists(car.Make, car.Model))
                    {
                        Console.WriteLine("Car already exists: " + car.Model);
                    }
                    else
                    {
                        carService.AddCar(car);
                        Console.WriteLine("Added Car: " + car.Model);
                    }
                }
            }

            List<Car> cars = carService.GetAllCars();
            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }

    }

}
