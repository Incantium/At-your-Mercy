using UnityEngine;

namespace Incantium.Extensions
{
    /// <summary>
    /// Class for extension methods related to exception-safe validation in runtime code.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Incantium-Core/blob/main/Documentation~/Extensions/Validation.md">
    /// Validation</seealso>
    public static class Validation
    {
        /// <summary>
        /// Method to validate if an object is null or not. This method will log the error message automatically if the
        /// object is found to be null.
        /// </summary>
        /// <param name="obj">The object to be validated for null.</param>
        /// <param name="error">The error message to be logged </param>
        /// <returns>True if the object is null, otherwise false.</returns>
        public static bool IsNull(this object obj, string error)
        {
            if (obj != null) return false;
            
            Debug.LogError(error);
            
            return true;
        }
    }
}