namespace Stwo.Core
{
    public enum Lifetime
    {
        /// <summary>
        ///     Instance will be created every time it is requested.
        /// </summary>
        PerDependency = 0,

        /// <summary>
        ///     A single instance will be created with in a lifetime scope.
        /// </summary>
        PerScope = 1,

        /// <summary>
        ///     Instance will be created once per requested context. Ex: HttpContext
        /// </summary>
        PerRequest = 2,

        /// <summary>
        ///     Instance will be singleton within the container lifetime.
        /// </summary>
        Singleton = 3
    }
}