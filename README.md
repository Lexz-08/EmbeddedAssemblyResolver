# EmbeddedAssemblyResolver
## Description
Makes referencing several embedded assemblies easy while resolving the dependency errors from non-existent files at the same time.

## How To Use
This code snippet is made assuming you have `using EmbeddedAssemblyResolver;` typed in the file that handles the program launch of your executable.
```csharp
AssemblyResolveManager.AddAssembly("ExampleDLL1", "MyClass.ExampleDLL1.dll");
AssemblyResolveManager.AddAssembly("ExampleDLL2", "MyClass.ExampleDLL2.dll");
AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolveManager.AssemblyErrorResolver;
```

## Download
[Standalone](https://github.com/Lexz-08/EmbeddedAssemblyResolver/releases/download/assembly-resolver/EmbeddedAssemblyResolver.dll)
