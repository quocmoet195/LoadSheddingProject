namespace LoadShedding.Middleware
{
    /// <summary>
    /// Configuration for load shedding behavior.
    /// </summary>
    public class LoadSheddingOptions
    {
        /// <summary>
        /// Maximum number of concurrent requests allowed.
        /// </summary>
        public int MaxConcurrentRequests { get; set; } = 2;
    }
}
