# [ReadOnly](../../Runtime/Attributes/ReadOnly.cs)

Class in `Incantium.Attributes` | Assembled in [`Incantium.Core`](../../README.md)

Extends [`PropertyAttribute`](https://docs.unity3d.com/ScriptReference/PropertyAttribute.html)

## Description

The ReadOnly attribute makes the field it is assigned to only readable, not editable. 

The main use case for this attribute is to show debug values in the Unity inspector while disabling altering these 
values for predictable results.

```csharp
using Incantium.Attributes;
using UnityEngine;

public class ExampleClass : MonoBehaviour
{
    [SerializeField]
    [ReadOnly]
    private string field = "Hello World!";
}
```
