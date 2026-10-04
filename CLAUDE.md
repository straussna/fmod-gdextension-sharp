# CLAUDE.md

C# wrapper (`FmodSharp` namespace) over the utopia-rise FMOD GDExtension for Godot .NET projects. The shipped
content is `addons/fmod-sharp/`; `tests/FmodSharp.Tests/` is an MSTest project that is excluded from the addon
and from Asset Library downloads (`.gitattributes` `export-ignore`).

## Build and test

- **.NET SDK 10.0.401** (the only SDK on this machine). Both projects target `net10.0`.
- The library compiles against the `GodotSharp` / `GodotSharpEditor` NuGet packages pinned in
  `fmod-gdextension-sharp.csproj`, not against an installed Godot. The tests need no Godot and no FMOD.

PowerShell:

```powershell
dotnet build "C:\source\repos\fmod-gdextension-sharp\fmod-gdextension-sharp.csproj"
dotnet test "C:\source\repos\fmod-gdextension-sharp\tests\FmodSharp.Tests\FmodSharp.Tests.csproj"
```

Bash tool:

```bash
dotnet build /c/source/repos/fmod-gdextension-sharp/fmod-gdextension-sharp.csproj
dotnet test /c/source/repos/fmod-gdextension-sharp/tests/FmodSharp.Tests/FmodSharp.Tests.csproj
```

`dotnet test` builds the library first.
