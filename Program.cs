using Car_Factory;

Console.WriteLine("Car Factory Simulation!");
Console.WriteLine("========================");

Console.WriteLine("\n[SCENARIO] Testing safety: Accelerating without starting...");
Console.WriteLine("------------------------\n");
var safetyCar = CarFactory.CreateCar(EngineType.Gasoline);
try
{
    safetyCar.Accelerate();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Caught expected exception: {ex.Message}");
}

Console.WriteLine("\n\n[SCENARIO] Creating a car with a gasoline engine and testing boundaries...");
Console.WriteLine("------------------------\n");
var car = CarFactory.CreateCar(EngineType.Gasoline);
car.Start();
car.Accelerate();
car.Accelerate();
car.Brake();
car.Stop();

Console.WriteLine("\n\n[SCENARIO] Testing start while already running...");
Console.WriteLine("------------------------\n");
var anotherCar = CarFactory.CreateCar(EngineType.Gasoline);
anotherCar.Start();
anotherCar.Start();


Console.WriteLine("\n\n[SCENARIO] Braking to 0 and stopping...");
Console.WriteLine("------------------------\n");
car.Brake();
car.Stop();
car.Brake();

Console.WriteLine("\n\n[SCENARIO] Testing Maximum Speed (200 km/h)...");
Console.WriteLine("------------------------\n");
for (int i = 0; i < 11; i++)
{
    car.Accelerate();
}

Console.WriteLine("\n\n[SCENARIO] Replacing engine with an electric one...");
Console.WriteLine("------------------------\n");
CarFactory.ReplaceEngine(car, EngineType.Electric);
car.Start();
car.Accelerate();
car.Brake();
car.Stop();

Console.WriteLine("\n\n[SCENARIO] Testing Hybrid engine transition (Threshold: 50 km/h)...");
Console.WriteLine("------------------------\n");
var hybridCar = CarFactory.CreateCar(EngineType.Hybrid);
hybridCar.Start();
Console.WriteLine("--- Below 50: Should use Electric ---");
hybridCar.Accelerate();
hybridCar.Accelerate();
Console.WriteLine("--- Crossing 50: Should switch to Gasoline ---");
hybridCar.Accelerate();
hybridCar.Brake();
Console.WriteLine("--- Back below 50: Should switch back to Electric ---");
hybridCar.Brake();
hybridCar.Stop();
hybridCar.Brake();
hybridCar.Stop();
