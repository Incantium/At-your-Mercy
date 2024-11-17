# Incantium Core

## Overview

Incantium Core is a custom-made Unity package specifically designed to make your development with the Unity Editor 
easier. It has many implementations for the most general use cases that Unity doesn't provide on its own in their 
editor. The content of this package is mostly in the form of simple attributes that lets you extend the Unity Inspector 
in handy ways, but it also has other tools to offer.

## Requirements

## Limitations

## References

| Class                                                             | Description                                                                                                                                                                       |
|-------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [AutoReference](Documentation~/Attributes/AutoReference.md)       | Attribute to auto reference a component attached to the same or a close family member of the current game object.                                                                 |
| [Button](Documentation~/Attributes/Button.md)                     | Attribute to create a simple button at the bottom of the Unity Inspector component view.                                                                                          |
| [DestroyOnTime](Documentation~/Components/DestroyOnTime.md)       | Class to automatically destroy the game object after a specified amount of seconds.                                                                                               |
| [DisableAtStartup](Documentation~/Components/DisableAtStartup.md) | Class for game objects that need to be disabled at start up or as soon as possible.                                                                                               |
| [EventBus](Documentation~/Events/EventBus.md)                     | Class for the default event bus implementation. Subscribe to this class to receive notification when something has changed.                                                       |
| [ReadOnly](Documentation~/Attributes/ReadOnly.md)                 | Attribute for disabling the editing of a field in the Unity Inspector.                                                                                                            |
| [Required](Documentation~/Attributes/Required.md)                 | Attribute for object reference fields that requires to be set in the Unity Inspector. Failing to do so will result in the game not playing.                                       |
| [SceneField](Documentation~/SceneField.md)                        | Class representing a reference field for scenes.                                                                                                                                  |
| [SingleBehaviour](Documentation~/SingleBehaviour.md)              | Class representing the singleton pattern for [MonoBehaviour](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/MonoBehaviour.html) and makes them globally available. |
| [Singleton](Documentation~/Singleton.md)                          | Class representing the singleton pattern for regular scripts and makes them globally available.                                                                                   |
| [TagMask](Documentation~/TagMask.md)                              | Class representing a field for one or multiple tags set in the editor.                                                                                                            |
| [Validation](Documentation~/Extensions/Validation.md)             | Static class for general-purpose error-prone validation.                                                                                                                          |
| [VisualScript](Documentation~/Attributes/VisualScript.md)         | Attribute for methods used by Unity's Visual Scripting.                                                                                                                           |
| [Waypoints](Documentation~/Data/Waypoints.md)                     | Class for the creation of a visual path with waypoints.                                                                                                                           |
