# Apos.Framework

Templates with my default MonoGame setups.

## Goal

Provide a base project structure that can be scaled.

## Templates

### [Apos.Framework.Simple](./Source/Simple/)

[![NuGet](https://img.shields.io/nuget/v/Apos.Framework.Simple.CSharp.svg)](https://www.nuget.org/packages/Apos.Framework.Simple.CSharp/) [![NuGet](https://img.shields.io/nuget/dt/Apos.Framework.Simple.CSharp.svg)](https://www.nuget.org/packages/Apos.Framework.Simple.CSharp/)

Template for doing a game with MonoGame. Comes with two platforms out of the box: DesktopGL and WindowsDX.

```
dotnet new install Apos.Framework.Simple.CSharp
dotnet new aposframeworksimple -o MyGame
```

---

### [Apos.Framework.Library](./Source/Library/)

[![NuGet](https://img.shields.io/nuget/v/Apos.Framework.Library.CSharp.svg)](https://www.nuget.org/packages/Apos.Framework.Library.CSharp/) [![NuGet](https://img.shields.io/nuget/dt/Apos.Framework.Library.CSharp.svg)](https://www.nuget.org/packages/Apos.Framework.Library.CSharp/)

Template for doing open source libraries. Fill in your own values:

```
dotnet new install Apos.Framework.Library.CSharp
dotnet new aposframeworklibrary -o Apos.Camera --repo https://github.com/Apostolique/Apos.Camera --branch main --description "Camera library for MonoGame." --param:author "Jean-David Moisan"
```

---

### [Apos.Framework](./Source/Full/)

[![NuGet](https://img.shields.io/nuget/v/Apos.Framework.CSharp.svg)](https://www.nuget.org/packages/Apos.Framework.CSharp/) [![NuGet](https://img.shields.io/nuget/dt/Apos.Framework.CSharp.svg)](https://www.nuget.org/packages/Apos.Framework.CSharp/)

Template for doing a game with MonoGame. Has a custom content pipeline as an alternative to the default MonoGame content pipeline. Comes with two platforms out of the box: DesktopGL and WindowsDX.

```
dotnet new install Apos.Framework.CSharp
dotnet new aposframework -o MyGame
```
