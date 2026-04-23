using Interfaces;

namespace Engines;

public class ElectricEngine : IEngine
{
    public int Speed { get; private set; }

    public void Increase() => Speed += 2;
    public void Decrease() => Speed -= 2;
    public void PrintStatus() => Console.WriteLine($"[Electric] Engine Speed: {Speed}");
}