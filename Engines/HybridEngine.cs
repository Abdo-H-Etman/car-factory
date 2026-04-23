using Interfaces;

namespace Engines;

public class HybridEngine : IEngine
{
    private readonly ElectricEngine _electricEngine = new ElectricEngine();
    private readonly GasolineEngine _gasolineEngine = new GasolineEngine();

    public int Speed { get; private set; }

    private IEngine Active => Speed < 50 ? _electricEngine : _gasolineEngine;

    public void Increase()
    {
        Speed++;
        SyncActive();
    }
    public void Decrease()
    {
        Speed--;
        SyncActive();
    }
    private void SyncActive()
    {
        while (_gasolineEngine.Speed > 0) _gasolineEngine.Decrease();
        while (_electricEngine.Speed > 0) _electricEngine.Decrease();

        IEngine engine = Active;
        while (engine.Speed < Speed) engine.Increase();
    }
    public void PrintStatus()
    {
        string activeType = Speed < 50 ? "Electric" : "Gasoline";
        Console.WriteLine($"[Hybrid Engine] speed: {Speed}, Active Engine: {activeType}");
    }
}
