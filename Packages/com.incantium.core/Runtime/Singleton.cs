namespace Incantium
{
    /// <summary>
    /// Class that represents the singleton pattern that is globally available.
    /// </summary>
    /// <typeparam name="T">The singleton typing.</typeparam>
    /// <seealso href="https://github.com/Incantium/Incantium-Core/blob/main/Documentation~/Singleton.md">Singleton</seealso>
    public class Singleton<T> where T : Singleton<T>, new()
    {
        private static T _instance;

        /// <summary>
        /// Static instance of the singleton.
        /// </summary>
        public static T instance => Instantiate();
        
        /// <summary>
        /// Method called when instantiating the singleton. If there isn't an instance of the singleton yet, this
        /// method will create a new one.
        /// </summary>
        /// <returns>The current or a new instance of the singleton.</returns>
        private static T Instantiate()
        {
            if (_instance != null) return _instance;
            return _instance = new T();
        }
    }
}