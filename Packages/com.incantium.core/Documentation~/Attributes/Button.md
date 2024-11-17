# [Button](../../Runtime/Attributes/Button.cs)

Class in `Incantium.Attributes` | Assembled in [`Incantium.Core`](../../README.md)

Extends [`Attribute`](https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/reflection-and-attributes/)

## Description

Button is a simple attribute to create a clickable button in the Unity inspector to call the method it is assigned to.

Under the hood, this attribute searches for any mention of this attribute in the current component being inspected. It 
will then draw a button under the default inspected component with any required buttons, linking them together.

```csharp
using UnityEngine;
using Incantium.Attributes

public class ExampleClass : MonoBehaviour
{
    [Button]
    private void Test() 
    {
        Debug.Log("Hello World!");
    }
}
```

> **Warning**: This attribute uses a custom editor for type Object and everything derived. This clashes with any other 
> custom editor of this typing. However, this is a general standard to make buttons on buttons visible in the Unity 
> Editor.

## Variables

### :green_book: `string` name

A custom name for the simple button.
