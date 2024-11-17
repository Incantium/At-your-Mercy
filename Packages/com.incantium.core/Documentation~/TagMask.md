# [TagField](../Runtime/TagMask.cs)

Class in `Incantium` | Assembled in [`Incantium.Core`](../README.md)

## Description

![TagMask](../Images~/TagMask.png)

With the TagMask, you can easily reference to one or more tags to be used in your other code.

The main use case for the TagMask is to remove all string references to tags in your code. With the TagMask, it is 
even possible to reference to multiple tags and compare them all to a game object.

> **Warning**: Changing a tag's name does not update the TagMask at the moment and will possibly result in wrong tags
> being selected in the TagMask at a later inspection. It is advisable to refrain from changing the name of tags while
> using the TagMask.

> **Warning**: This class can only handle a maximum of 32 tags (7 build-in, 25 custom) due to using an internal integer
> bitmask. Any selected tag which would be number 33 or higher would cause an 
> [OverflowException](https://learn.microsoft.com/en-us/dotnet/api/system.overflowexception?view=net-8.0) to be thrown.
> As a work-around, this class will display an error warning when it detects more than 32 tags in the project.

## Methods

### :green_book: `bool` Compare(`string`)

Checks if a tag is set in the tag mask.

### :green_book: `bool` Compare(`GameObject`)

Checks if any tag in the TagMask matches the game object's tag.
