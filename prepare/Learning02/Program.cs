using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Learning02 World!");

var cars = new List<Car>();

        Car car = new()
        {
            make = "Honda",
            model = "Civic",
            gallons = 10,
            milesPerGallon = 30,
            year = 2021
        };
        var owner = new Person

        {
            name = "bob",
            phone = "333-333-3333"
        };

        car.owner = owner;

        cars.Add(car);

        car = new Car
        {
            make = "Ford",
            model = "F-150",
            year = 2023,
            gallons = 30,
            milesPerGallon = 5
        };

        owner = new Person
        {
            name = "Dug",
            phone = "444-444-4444"
        };

        car.owner = owner;

        cars.Add(car);
        car = new Car{
            make = "Chevy",
            model = "Silverado",
            year = 2002,
            gallons = 24,
            milesPerGallon = 10,

        };

        owner = new Person
        {
            name = "Guh",
            phone = "555-555-5555"
        };
        
        car.owner = owner;



        cars.Add(car);

        foreach(var c in cars)
        {
            c.Display();
            // System.Console.WriteLine($"{c.make} {c.model}: TotalRange = {c.TotalRange()}");
        }



    }
}
