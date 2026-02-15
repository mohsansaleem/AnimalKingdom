# Animal Kingdom
**Modular Farm Simulation with Reusable Generic Systems**

A technical demonstration of scalable, modular architecture designed for rapid feature expansion. Showcases production-grade patterns including generic popup systems, state machines, and persistent game state—techniques refined over 10+ years building mobile titles at Ubisoft and other studios.

## 🎥 Demo
[![Watch Demo](http://img.youtube.com/vi/momBUi4V770/0.jpg)](http://www.youtube.com/watch?v=momBUi4V770 "Animal Kingdom Demo")

## 🎮 Core Gameplay

**Resource Gathering** – Explore the map to collect animals  
**Economic Loop** – Convert captured animals to cash at the farm  
**Persistent State** – Save/load game progress with metadata-driven configuration

## 🏗️ Technical Architecture

**Scalable Design Patterns:**
- **MVP Architecture** – Strict separation enabling parallel development
- **Generic Popup System** – Reusable UI framework for dialogs and notifications
- **State Machine** – Clean state transitions (Gathering, Navigation, Farm Management)
- **Generic Object Pooling** – Memory-optimized entity management
- **Dependency Injection (Zenject)** – Modular components with minimal coupling
- **Reactive Programming (UniRx)** – Event-driven updates for responsive UI
- **Promise-based Async** – Non-blocking operations for smooth gameplay

**Data Architecture:**
- Context-driven scene management (Bootstrap → MainHub → GamePlay)
- Metadata vs GameState separation for clean persistence
- ScriptableObject-based configuration for designer workflows
- JSON serialization for save/load functionality

## 📁 Project Structure

```
Assets/
├── Scripts/
│   ├── AnimalKingdom/
│   │   ├── Contexts/       # Controllers
│   │   ├── Views/          # UI and presentation layer
│   │   ├── Models/         # Data, RemoteData, RemoteDataModels
│   │   └── Commands/       # Game actions and operations
│   └── Core/               # Reusable generic abstractions (submodule)
├── Scenes/                 # Scene files
└── Resources/Scenes/       # Scene-specific resources
```

## 🔧 Tech Stack

| Technology | Purpose |
|-----------|---------|
| **Unity 2019.4.0f1** | LTS game engine |
| **Zenject** | Dependency injection framework |
| **UniRx** | Reactive extensions |
| **C# Promises** | Asynchronous operations |

## 🚀 Quick Start

1. Clone the repository
2. Open with Unity 2019.4.0f1+
3. Enable **Always Start from Startup Scene** in `/MainMenu/Game/`
4. Press Play

*Note: Delete `StreamingAssets/GameState.json` and `MetaData.json` to reset after modifying ScriptableObjects.*

## 🎯 Generic Systems Highlight

**Reusable Popup Framework** – Modal dialog system used across multiple projects  
**Universal Pooling System** – Generic pooling applicable to any GameObject type  
**Flexible State Machine** – Adaptable state management for various game modes  

These systems demonstrate production-ready code designed for reusability across multiple titles—a critical skill for mobile game development where rapid iteration drives success.

## 💼 About the Developer

Senior Game Developer with 10+ years specializing in mobile game architecture and reusable systems. Experience includes:
- **Ubisoft** – Mobile titles including Clash of Beasts (war strategy)
- Custom editor tools reducing designer iteration time
- Generic systems deployed across multiple production titles
- Persistent state management for millions of players

## 📫 Connect
Building scalable architectures for mobile games or rapid prototyping systems? Let's connect.

[LinkedIn](https://linkedin.com/in/mohsansaleem) | [Portfolio](https://github.com/mohsansaleem)

---

## Topics
`unity3d` `mvp-architecture` `zenject` `unirx` `state-machine` `promises` `asynchronous-programming` `gamestate` `popup` `pooling`
