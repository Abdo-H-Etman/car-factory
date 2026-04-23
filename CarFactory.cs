using Engines;
using Interfaces;

namespace Car_Factory;

public class CarFactory
{
    public static Car CreateCar(EngineType engineType)
    {
        IEngine engine = BuildEngine(engineType);

        Console.WriteLine($"CarFactory: Created car with {engine.GetType().Name} engine.");
        return new Car(engine);
    }

    private static IEngine BuildEngine(EngineType engineType)
    {
        return engineType switch
        {
            EngineType.Gasoline => new GasolineEngine(),
            EngineType.Electric => new ElectricEngine(),
            EngineType.Hybrid => new HybridEngine(),
            _ => throw new ArgumentException("Invalid engine type")
        };
    }

    public static void ReplaceEngine(Car car, EngineType newEngineType)
    {
        IEngine newEngine = BuildEngine(newEngineType);

        car.SetEngine(newEngine);
    }
}