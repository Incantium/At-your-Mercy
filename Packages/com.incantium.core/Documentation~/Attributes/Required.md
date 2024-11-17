# [Required](../../Runtime/Attributes/Required.cs)

Class in `Incantium.Attributes` | Assembled in [`Incantium.Core`](../../README.md)

Extends [`PropertyAttribute`](https://docs.unity3d.com/ScriptReference/PropertyAttribute.html)

## Description

![Required](../../Images~/Required.png)

The Required attribute is a handy tool to force developers to reference an object in the field this attribute is added 
to.

The main use case for the use of this attribute is to create an environment where you know for certain that a field is
always correctly setup in the Unity Editor. It is a common occurrence that developers forget to set certain field to the
correct reference. With this attribute, it is not possible to use play modes while having unset fields.

Because play modes cannot be started with any unset Required fields, this class also includes a method to check if all
references are set correctly without starting play modes. To do this, use "Services -> Validation -> Required fields".

```csharp
using Incantium.Attributes;
using UnityEngine;

public class ExampleClass : MonoBehaviour
{
    [SerializeField]
    [Required]
    private AudioClip important;
}
```

> **Info**: Field with the Required attribute in prefab modes are exempt from being filled. However, this does not apply 
> to the prefab once it is included in a scene.
