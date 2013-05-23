namespace GW2DotNET.Infrastructure
{
    /// <summary>
    /// An item returned by a call to world_names.JSON
    /// </summary>
    public class ApiWorldName
    {
        /// <summary>
        /// Gets or sets the world ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the world name
        /// </summary>
        public string Name { get; set; }
    }
}