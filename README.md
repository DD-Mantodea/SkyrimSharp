<h1 align="center">Skyrim Sharp</h1>

<div align="center">

A C# runtime and bindings of SKSE

</div>

## Description

This mod is for Skyrim, it provides a custom C# runtime using hostfxr, and has some compat with mods like Prisma and OStim, also, I made some new features for the mods and SKSE. Here is the [nexus link](https://www.nexusmods.com/games/skyrimspecialedition/mods/183149).

About the bindings, I done the current part **by myself without any vibe codes** so it's not complete now, if you have any need about the api, you could write them yourself then open a PR, or you could also open an issue to ask me about adding them.

My design of the bindings is kinda complex but i think it's a must cuz C# do not support multi-inherit class. 

#### Classes in inherit chain or have many virtual methods

- These class will be devided into two parts: `always-used` and `I-think-non-used`. They all have similar struct like a external class/struct and a internal struct for **Interop**. Then i could use structure like this to express they have inheritance.
```csharp
public unsafe class ExampleParent
{
    public struct Internal;
}

public unsafe class ExampleClass
{
    public struct Internal
    {
        internal ExampleParent.Internal Base;
    }
}
```

- As for multi-inherit, just use multiple bases like `Base_0`, `Base_1` etc. But this struct could not use Pattern-Matching for these bindings, so i also added interfaces to express the C# inheritance.
```csharp
public unsafe class ExampleParent : IExampleParent
{
    public struct Internal;
}

public interface IExampleParent;

public unsafe class ExampleClass : IExampleClass
{
    public struct Internal
    {
        internal ExampleParent.Internal Base;
    }
}

public interface IExampleClass : IExampleParent;
```

By using this, some of the methods could be declared in the extension class of interfaces to avoid duplicated works.

- When it comes to the native methods calling, i will use `Unsafe.AsPointer` to get the VTABLE from these Internal structs and use `delegate* unmanaged` to call the methods. I think it should have good performance.

</br>

- And for classes needed to be made into instance and used in C# codes, they need to implements `interface IFromNative`.
```csharp
public unsafe interface IFromNative
{
    nint Native { get; }
}

public unsafe interface IFromNative<TManaged> : IFromNative where TManaged : IFromNative<TManaged>
{
    public abstract static TManaged FromNative(nint ptr);
}

public unsafe interface IFromNative<TManaged, TNative> : IFromNative<TManaged> where TManaged : IFromNative<TManaged, TNative> where TNative : unmanaged
{
    public abstract static implicit operator TManaged(TNative* ptr);

    public abstract static implicit operator TNative*(TManaged instance);
}
```

They are three levels that extension classes need to use, if you only need a native ptr and have no generic infos, you could use simple `IFromNative` to get the nint field and convert it to anything you want, but make sure you deal it with **try-catch blocks**. Then, if you need to get a managed instance and has the managed generic info, you could use the second one. The third one is mainly for the class declarations so that you won't forget to make the implicit operators.

</br>

- If the class is `I-think-non-used`, i will make the external class to `unsafe readonly struct`.

#### Other classes

- This part is kinda easy, i just make them with only a `unsafe readonly struct`. They are mainly like logic classes or the engine's base classes.

#### For AddressLib

- I do made a simple binding for that, but i only made few features like:
```csharp
public unsafe static class AddressLib
{
    internal static delegate* unmanaged<ulong, ulong> _id2offset;

    public static ulong ID2Offset(ulong id) => _id2offset == null ? 0 : _id2offset(id);

    internal static delegate* unmanaged<ulong> _base;

    public static ulong Base() => _base == null ? 0 : _base();

    public static ulong GetAddr(ulong id)
    {
        var offset = ID2Offset(id);

        if (offset == 0)
            return 0;

        return Base() + offset;
    }
}
```

These could be used for some static methods calling. But i haven't made anything about hooks, maybe in the future you could write the hooks using C# delegates.

#### After all

- This is the first time i make such a big binding program and i m not that good at C++ so if anyone finds any problem plz tell me. Also, if you wanna take part in it, just join!