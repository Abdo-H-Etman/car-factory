namespace Interfaces;

public interface IEngine
{
    int Speed { get; }
    void increase();
    void decrease();
    void PrintStatus();
}