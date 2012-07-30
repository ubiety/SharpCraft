namespace SharpCraft
{
	/// <summary>
	/// Stores the server settings.
	/// </summary>
	public class Settings
	{
		/// <summary>
		/// Name of the world file to load.
		/// </summary>
		public string WorldName { get; set; }

		/// <summary>
		/// Seed used to generate a new world.
		/// </summary>
		public string Seed { get; set; }

		/// <summary>
		/// Port to connect to.
		/// </summary>
		public int Port { get; set; }
	}
}
