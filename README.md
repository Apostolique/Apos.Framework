# Apos.Framework

Game architecture for MonoGame.

# Getting Started

1. Create a folder for your game.
2. Open your favorite terminal in that folder and run the following commands:
```
dotnet new --install Apos.Framework.CSharp
dotnet new Apos.Framework -o MyGame
```

# Structure

This framework is divided in two directories: `Game` and `Platforms`.

## Game

Contains game code that can be shared between multiple platforms. The game code is divided in two parts: `Layer0` and `Layer1`. Game also contains two content pipelines. The default MonoGame Content Pipeline that sits in the `Content` directory and a custom game pipeline. The custom pipeline is coded in `Game/Pipeline/` and the assets sit in the `Assets` directory. This custom pipeline generates the class `AssetLinks.cs` in `Layer1`.

### Layer0

`Layer0` is where you can put code that can be used by prebuild tools such as a content pipeline. It's best to keep `Layer0` as lean as possible.

### Layer1

`Layer1` sits on top of `Layer0`. If a prebuild tool generates code, it will be put in `Layer1`. For example, a content pipeline could generate a C# class with links to the asset files. IDEs can then provide autocomplete and error checking when the links change.

## Platforms

This framework comes with two target platforms out of the box: Core and DirectX. More target platforms can be added as needed.

Along with the platforms, there's a standalone custom Pipeline project. Running this builds the assets from `Game/Assets/`.