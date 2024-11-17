# [Singleton](../Runtime/Singleton.cs)

Class in `Incantium` | Assembled in [`Incantium.Core`](../README.md)

## Description

This abstract class transforms any other class into a singleton pattern without any needed code. This class is the same 
as the [SingleBehaviour.md](SingleBehaviour.md), only this one is specialized for all default classes (not for 
[MonoBehaviour](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/MonoBehaviour.html)).

> **Warning**: This class doesn't allow multiple instances of the same singleton to be instantiated in the game, as
> that goes against the singleton pattern. Any subsequent adding of this class will be overwritten.

## Variables

### :green_book: `T` instance

The static instance of the singleton.
