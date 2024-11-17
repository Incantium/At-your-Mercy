# [SingleBehaviour](../Runtime/SingleBehaviour.cs)

Class in `Incantium` | Assembled in [`Incantium.Core`](../README.md)

Extends [`MonoBehaviour`](https://docs.unity3d.com/ScriptReference/MonoBehaviour.html)

## Description

This abstract class transforms any 
[MonoBehaviour](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/MonoBehaviour.html) into a singleton
pattern without any needed code. This class is the same as the [Singleton](Singleton.md), specialized for
[MonoBehaviour](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/MonoBehaviour.html) only.

> **Warning**: This class doesn't allow multiple instances of the same singleton to be instantiated in the game, as 
> that goes against the singleton pattern. Any subsequent adding of this class will be removed from the game objects.

## Variables

### :green_book: `T` instance

The static instance of the singleton.
