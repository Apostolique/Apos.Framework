# GameName

## Restore

```
dotnet restore Platforms/DesktopGL
dotnet restore Platforms/WindowsDX
```

## Run

```
dotnet run --project Platforms/DesktopGL
dotnet run --project Platforms/WindowsDX
```

## MonoGame Content Pipeline Editor

To run the MonoGame content pipeline editor, you can use the following command:

```
dotnet mgcb-editor Game/Content/Content.mgcb
```

## Debug

In vscode, you can debug by pressing F5.

## Publish

```
dotnet publish Platforms/DesktopGL -c Release -r win-x64 --output artifacts/windows
dotnet publish Platforms/DesktopGL -c Release -r osx-x64 --output artifacts/osx
dotnet publish Platforms/DesktopGL -c Release -r linux-x64 --output artifacts/linux
```

```
dotnet publish Platforms/WindowsDX -c Release -r win-x64 --output build-windowsdx
```

## Structure

This template is divided in two directories: `Game` and `Platforms`.

### Game

Contains game code that can be shared between multiple platforms. The game code is divided in two parts: `Layer0` and `Layer1`. Game also contains two content pipelines. The default MonoGame Content Pipeline that sits in the `Content` directory and a custom game pipeline. The custom pipeline is coded in `Game/Pipeline/` and the assets sit in the `Assets` directory. This custom pipeline generates the class `AssetLinks.cs` in `Layer1`.

### Layer0

`Layer0` is where you can put code that can be used by prebuild tools such as a content pipeline. It's best to keep `Layer0` as lean as possible.

### Layer1

`Layer1` sits on top of `Layer0`. If a prebuild tool generates code, it will be put in `Layer1`. For example, a content pipeline could generate a C# class with links to the asset files. IDEs can then provide autocomplete and error checking when the links change.

### Platforms

This template comes with two target platforms out of the box: DesktopGL and WindowsDX. More target platforms can be added as needed.

Along with the platforms, there's a standalone custom Pipeline project. Running this builds the assets from `Game/Assets/`.
