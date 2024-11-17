/// <summary>
/// Interface for game objects that can be killed by external sources.
/// </summary>
public interface IKillable
{
    /// <summary>
    /// Method to kill a game object.
    /// </summary>
    /// <param name="reason">The reason why it was killed.</param>
    void Kill(string reason = null);
}