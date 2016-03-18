namespace Transfer.Background.Interfaces
{
    /// <summary>
    /// Interface used by any dependency that wants to know when the system starts up
    /// </summary>
    public interface IStartup
    {
        /// <summary>
        /// Do whatever is needed to get things booted up
        /// </summary>
        void Start();
    }
}
