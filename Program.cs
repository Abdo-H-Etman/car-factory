using Car_Factory;

Console.WriteLine("Car Factory Simulation!");
Console.WriteLine("========================\n");

Console.WriteLine("\nCreating a car with a gasoline engine...");
Console.WriteLine("------------------------\n");
var car = CarFactory.CreateCar(EngineType.Gasoline);
car.Start();
car.Accelerate();
car.Accelerate();
car.Brake();
car.Stop();
car.Brake();
car.Stop();

Console.WriteLine("\nReplacing engine with an electric one...");
Console.WriteLine("------------------------\n");
CarFactory.ReplaceEngine(car, EngineType.Electric);
car.Start();
car.Accelerate();
car.Brake();
car.Stop();

Console.WriteLine("\nCreating a new car with a hybrid engine...");
Console.WriteLine("------------------------\n");
var hybridCar = CarFactory.CreateCar(EngineType.Hybrid);
hybridCar.Start();
hybridCar.Accelerate();
hybridCar.Accelerate();
hybridCar.Accelerate();
hybridCar.Brake();
hybridCar.Brake();
hybridCar.Stop();
hybridCar.Brake();
hybridCar.Stop();
