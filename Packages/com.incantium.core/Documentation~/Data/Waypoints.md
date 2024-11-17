# [Waypoints](../../Runtime/Data/Waypoints.cs)

Class in `Incantium.Data` | Assembled in [`Incantium.Core`](../../README.md)

Extends [`ScriptableObject`](https://docs.unity3d.com/ScriptReference/ScriptableObject.html)

## Description

![Waypoints](../../Images~/Waypoints.png)

The Waypoints is a [ScriptableObject](https://docs.unity3d.com/ScriptReference/ScriptableObject.html) that lets you 
create a path through the game space.

The main use case of the Waypoint is the functionality to create a path something can follow without the use of dummy 
game objects. That is why this component uses gizmo's to show the path it creates in the current scene.

With the Waypoints, you can add new points to the list. Each point and line in between is a gizmo, so they won't affect 
the game.

## Variables

### :green_book: `int` Count

The amount of points in the path.

### :green_book: `List<Vector3>` points

The positions of the points in the Waypoints.

### :green_book: `PathType` type

Determines if the points in the Waypoints are Linear or in a Loop.
