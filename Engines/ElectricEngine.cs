using Interfaces;

namespace Engines;

public class ElectricEngine : IEngine
{
    public int Speed { get; private set; }

    public void increase() => Speed += 2;
    public void decrease() => Speed -= 2;
    public void PrintStatus() => Console.WriteLine($"[Electric] Engine Speed: {Speed}");
}