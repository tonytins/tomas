# Interfaces

Since 19.1, TOMAS uses a modular interface design for writing and executing programs. At the moment, the operating system doesn't yet support loading assemblies that would take advantage of this API, but it is being looked into.

## Design

``IProgram`` is used to create the actual program while ``IShell`` executes the respective program from a dictionary. While still early in development, the approach has allowed for easy migration from one major release of COSMOS to another with little to no modifications of the code itself.

```csharp
public interface IProgram
{
    string Name { get; }

    string Description { get; }

    bool Entry(IShell shell, IEnumerable<KeyValuePair<string, object>> arguments);
}
```

```csharp
public interface IShell
{
    string ReadLine { get; }

    Dictionary<string, IProgram> Programs { get; }

    IEnumerable<KeyValuePair<string, object>>? ParseArguments(IProgram program, string[] arguments);
}
```
