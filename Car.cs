using Interfaces;

namespace Car_Factory;

public class Car
{
    private int _speed;
    private bool _isRunning;
    private IEngine _engine;

    private const int MaxSpeed = 200;
    private const int SpeedIncrement = 20;
    public Car(IEngine engine) =>
            _engine = engine ?? throw new ArgumentNullException(nameof(engine));

    public void SetEngine(IEngine engine)
    {
        _engine = engine ?? throw new ArgumentNullException(nameof(engine));
        Console.WriteLine($"Engine replaced with {engine.GetType().Name}.");
    }

    public void Start()
    {
        _isRunning = true;
        _speed = 0;
    }

    public void Accelerate()
    {
        AssertRunning();
        if (_speed >= MaxSpeed)
        {
            Console.WriteLine($"Maximum speed ({MaxSpeed} km/h) reached. Cannot accelerate further.");
            return;
        }

        int steps = Math.Min(SpeedIncrement, MaxSpeed - _speed);

        for (int i = 0; i < steps; i++)
        {
            _speed++;
            _engine.increase();
        }

        Console.WriteLine($"Accelerating... Current Speed: {_speed} km/h");
        AdviseEngine();
    }

    public void Brake()
    {
        AssertRunning();
        if (_speed <= 0)
        {
            Console.WriteLine("Car is already stopped.");
            return;
        }

        for (int i = 0; i < 20; i++)
        {
            _speed--;
            _engine.decrease();
        }

        Console.WriteLine($"Braking... Current Speed: {_speed} km/h");
        AdviseEngine();
    }

    public void Stop()
    {
        if (!_isRunning)
        {
            Console.WriteLine("Car is not running.");
            return;
        }
        if (_speed == 0) Console.WriteLine("Car stopped.");
        else Console.WriteLine("Car is still moving. Please brake to stop.");
    }

    private void AssertRunning()
    {
        if (!_isRunning)
            throw new InvalidOperationException("Car is not started. Call Start() first.");
    }
    private void AdviseEngine()
    {
        while (_engine.Speed < _speed) _engine.increase();
        while (_engine.Speed > _speed) _engine.decrease();
        _engine.PrintStatus();
    }
}