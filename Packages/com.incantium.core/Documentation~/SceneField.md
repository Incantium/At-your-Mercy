# [SceneField](../Runtime/SceneField.cs)

Class in `Incantium` | Assembled in [`Incantium.Core`](../README.md)

Implements 
[`ISerializationCallbackReceiver`](https://docs.unity3d.com/ScriptReference/ISerializationCallbackReceiver.html)

## Description

Use the SceneField to create a reference field in the Unity inspector for scenes.

Unity's default implementation for handling scene references is string-based. This is highly inefficient and 
error-prone, especially when a scene changes its name. This class is a solution to safely handle scene references that
update automatically when any changes in name occur.

In truth, this class still saves the scene reference as a string. However, it has a build-in feature to automatically
update the string from the actual scene reference when starting playmode or creating a new build. As such, this class
is always in sync with the scene it references.

```csharp
using Incantium;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    private SceneField scene;
    
    private void Start()
    {
        if (scene.isLoaded) return;
        
        scene.LoadAsync();
    }
}
```

## Variables

### :green_book: `string` name

The scene name stored internally for referencing.

### :green_book: `bool` isLoaded

IsLoaded is set to true after loading has completed and objects have been enabled.

## Methods

### :green_book: `AsyncOperation` LoadAsync(`LoadSceneMode = LoadSceneMode.Single`)

Loads the scene asynchronously in the background.
