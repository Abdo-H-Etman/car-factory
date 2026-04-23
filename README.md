# Quantum Car Design

A C# console application demonstrating the **Strategy** and **Factory** design patterns through a modular car engine simulation. Engines are interchangeable at runtime, and a dedicated factory handles both car creation and engine replacement.

---

## Design Patterns

### Strategy Pattern
`IEngine` is the strategy interface. `Car` holds a reference to it and delegates all internal speed synchronization through it. Adding a new engine type requires only a new class that implements `IEngine` — the `Car` class never needs to change.

### Factory Pattern
`CarFactory` centralises object creation:
- `CreateCar(EngineType)` — builds the correct engine and returns a ready-to-use `Car`
- `ReplaceEngine(Car, EngineType)` — hot-swaps the engine on an existing car instance

---


## Engine Types

| Class | Fuel | Active when |
|---|---|---|
| `GasolineEngine` | Gas | Always (when installed) |
| `ElectronicEngine` | Electric | Always (when installed) |
| `MixedHybridEngine` | Gas + Electric | Electric below 50 km/h, Gas at 50 km/h and above |

The hybrid engine is **cost-optimized** — only one internal engine runs at any given time. The idle engine is always held at 0 km/h.

---

## Car Operations

| Method | Behaviour |
|---|---|
| `Start()` | Starts the engine at 0 km/h. Blocked if already running. |
| `Stop()` | Stops the engine. Blocked if speed is not 0 — brake first. |
| `Accelerate()` | Increases speed by 20 km/h, up to a maximum of 200 km/h. |
| `Brake()` | Decreases speed by 20 km/h, down to a minimum of 0 km/h. |

After every speed change, the car calls `AdviseEngine()` which synchronises the installed engine's internal speed step by step using `Increase()` and `Decrease()`.

---

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

### Run the project

```bash
git clone https://github.com/Abdo-H-Etman/car-factory.git
cd car-factory
dotnet run
```

### Build only

```bash
dotnet build
```