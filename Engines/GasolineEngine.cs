using Interfaces;

namespace Engines;

public class GasolineEngine : IEngine
{
    public int Speed { get; private set; }

    public void Increase() => Speed++;
    public void Decrease() => Speed--;
    public void PrintStatus() => Console.WriteLine($"[Gasoline] Engine Speed: {Speed}");
}