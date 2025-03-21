﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        public Car(int id, string model, string make, int year, string color)
        {
            Id = id;
            Model = model;
            Make = make;
            Year = year;
            Color = color;
        }
        
        public bool Start()
        {
            Console.WriteLine("Starting...");
            return true;
        }

        public void Accelerate()
        {
            Console.WriteLine("Accelerating...");
        }

        public bool TurnKey()
        {
            Console.WriteLine("Turning key and Starting...");
            return true;
        }

        public void Brake()
        {

            Console.WriteLine("Braking...");
        }

        public void shift()
        {
            Console.WriteLine("Shifting...");
        }


        public override string ToString()
        {
            return $"Id: {Id}, Model: {Model}, Make: {Make}, Year: {Year}, Color: {Color}";
        }
        //static void Main(string[] args)
        ////{
        ////    Car car = new Car(1, "Civic", "Honda", 2020, "Red");
        ////    Console.WriteLine(car);
        ////    bool started = car.TurnKey();
        ////    if (started) { car.shift(); car.Accelerate(); } else Console.WriteLine("Car failed to start");
        ////}
    }
}
