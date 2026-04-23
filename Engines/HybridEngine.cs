using Interfaces;

namespace Engines;

public class HybridEngine : IEngine
{
    private readonly ElectricEngine _electricEngine = new ElectricEngine();
    private readonly GasolineEngine _gasolineEngine = new GasolineEngine();

    public int Speed { get; private set; }

    private IEngine Active => Speed < 50 ? _electricEngine : _gasolineEngine;

    public void increase()
    {
        Speed++;
        SyncActive();
    }
    public void decrease()
    {
        Speed--;
        SyncActive();
    }
    private void SyncActive()
    {
        while (_gasolineEngine.Speed > 0) _gasolineEngine.decrease();
        while (_electricEngine.Speed > 0) _electricEngine.decrease();

        IEngine engine = Active;
        while (engine.Speed < Speed) engine.increase();
    }
    public void PrintStatus()
    {
        string activeType = Speed < 50 ? "Electric" : "Gasoline";
        Console.WriteLine($"[Hybrid Engine] speed: {Speed}, Active Engine: {activeType}");
    }
}
