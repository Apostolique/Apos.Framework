# Apos.Framework

Templates with my default MonoGame setups.

## Goal

Provide a base project structure that can be scaled.

## Builds

### Apos.Framework

[![NuGet](https://img.shields.io/nuget/v/Apos.Framework.CSharp.svg)](https://www.nuget.org/packages/Apos.Framework.CSharp/) [![NuGet](https://img.shields.io/nuget/dt/Apos.Framework.CSharp.svg)](https://www.nuget.org/packages/Apos.Framework.CSharp/)

---

### Apos.Framework.Simple

[![NuGet](https://img.shields.io/nuget/v/Apos.Framework.Simple.CSharp.svg)](https://www.nuget.org/packages/Apos.Framework.Simple.CSharp/) [![NuGet](https://img.shields.io/nuget/dt/Apos.Framework.Simple.CSharp.svg)](https://www.nuget.org/packages/Apos.Framework.Simple.CSharp/)

---

### Apos.Framework.Library

[![NuGet](https://img.shields.io/nuget/v/Apos.Framework.Library.CSharp.svg)](https://www.nuget.org/packages/Apos.Framework.Library.CSharp/) [![NuGet](https://img.shields.io/nuget/dt/Apos.Framework.Library.CSharp.svg)](https://www.nuget.org/packages/Apos.Framework.Library.CSharp/)

## Getting Started

1. Create a folder for your game.
2. Open your favorite terminal in that folder and run the following commands:
```
dotnet new --install aposframework
dotnet new aposframework -o MyGame
```
I also provide simplified templates without my custom content pipeline:
```
dotnet new --install aposframeworksimple
dotnet new aposframeworksimple -o MyGame
```
3. To get the graphical MonoGame Pipeline Builder Editor:
```
dotnet tool install --global dotnet-mgcb-editor
mgcb-editor --register
```

Template for doing open source libraries. Fill in your own values:

```
dotnet new --install aposframeworklibrary
dotnet new aposframeworklibrary -o Apos.Camera --repo https://github.com/Apostolique/Apos.Camera --branch main --description "Camera library for MonoGame." --param:author "Jean-David Moisan"
```
