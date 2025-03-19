using MongoDB.Driver;
using System.Collections.Generic;
using test;

public class CarService
{
    private readonly IMongoCollection<Car> _cars;

    public CarService(string connectionString, string dbName, string collectionName)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(dbName);
        _cars = database.GetCollection<Car>(collectionName);
    }

    public List<Car> GetAllCars()
    {
        return _cars.Find(car => true).ToList();
    }

    public Car GetCarById(int id)
    {
        return _cars.Find(car => car.Id == id).FirstOrDefault();
    }

    public void AddCar(Car car)
    {
        if (car == null)
            throw new ArgumentNullException(nameof(car));

        if (CarExists(car.Make, car.Model))
            throw new InvalidOperationException("Car already exists.");

        _cars.InsertOne(car);
    }

    public void UpdateCar(int id, Car updatedCar)
    {
        _cars.ReplaceOne(car => car.Id == id, updatedCar);
    }

    public void DeleteCar(int id)
    {
        var result = _cars.DeleteOne(car => car.Id == id);

        if (result.DeletedCount == 0)
        {
            throw new InvalidOperationException("Car does not exist or was already deleted.");
        }
    }

    public bool CarExists(string make, string model)
    {
        return _cars.Find(car => car.Make == make && car.Model == model).Any();
    }
}
