namespace Interfaces;

public interface IEngine
{
    int Speed { get; }
    void Increase();
    void Decrease();
    void PrintStatus();
}