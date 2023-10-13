using System;

public abstract class Vehicle
{
    public string FactoryName { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public double DriveTime { get; set; }
    public string DrivePath { get; set; }
    public DateTime ProductionDate { get; }

    public Vehicle(string factoryName, string model, string color, double driveTime, string drivePath)
    {
        FactoryName = factoryName;
        Model = model;
        Color = color;
        DriveTime = driveTime;
        DrivePath = drivePath;
        ProductionDate = DateTime.Now;
    }

    public abstract string DefineNatureHarmness();

    public double AverageSpeed()
    {
        double distance = double.Parse(DrivePath);
        double time = DriveTime;
        return distance / time;
    }

    public virtual void GetInfo()
    {
        Console.WriteLine("Factory Name: " + FactoryName);
        Console.WriteLine("Model: " + Model);
        Console.WriteLine("Color: " + Color);
        Console.WriteLine("Drive Time: " + DriveTime + " hours");
        Console.WriteLine("Drive Path: " + DrivePath + " km");
        Console.WriteLine("Production Date: " + ProductionDate.ToString("yyyy-MM-dd"));
        Console.WriteLine("Average Speed: " + AverageSpeed() + " km/h");
        Console.WriteLine("Nature Harmness: " + DefineNatureHarmness());
    }

    public override string ToString()
    {
        return $"Factory Name: {FactoryName}, Model: {Model}";
    }
}

public class Car : Vehicle
{
    public int DoorCount { get; set; }
    public bool IsElectricCar { get; set; }

    public Car(string factoryName, string model, string color, double driveTime, string drivePath, int doorCount, bool isElectricCar)
        : base(factoryName, model, color, driveTime, drivePath)
    {
        DoorCount = doorCount;
        IsElectricCar = isElectricCar;
    }

    public override string DefineNatureHarmness()
    {
        return IsElectricCar ? "low" : "high";
    }

    public override void GetInfo()
    {
        base.GetInfo();
        Console.WriteLine("Door Count: " + DoorCount);
        Console.WriteLine("Is Electric Car: " + (IsElectricCar ? "Yes" : "No"));
    }
}

public class Bicycle : Vehicle
{
    public string Type { get; set; }

    public Bicycle(string factoryName, string model, string color, double driveTime, string drivePath, string type)
        : base(factoryName, model, color, driveTime, drivePath)
    {
        Type = type;
    }

    public override string DefineNatureHarmness()
    {
        return "none";
    }

    public override void GetInfo()
    {
        base.GetInfo();
        Console.WriteLine("Type: " + Type);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Vehicle[] vehicles = new Vehicle[]
        {
            new Car("Ford", "Mustang", "Red", 4.5, "200", 2, true),
            new Car("Tesla", "Model S", "Black", 5.0, "250", 4, true),
            new Bicycle("Trek", "Mountain Bike", "Green", 2.0, "15", "Mountain"),
            new Bicycle("Giant", "Road Bike", "Blue", 1.5, "20", "Road"),
        };

        foreach (var vehicle in vehicles)
        {
            Console.WriteLine("Vehicle Information:");
            vehicle.GetInfo();
            Console.WriteLine("\n----------------\n");
        }
    }
}
