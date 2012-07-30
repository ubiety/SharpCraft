using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using SharpCraft.Net;
using SharpCraft.World;
using YamlDotNet.RepresentationModel.Serialization;

namespace SharpCraft
{
	/// <summary>
	/// Represents the server and hosts multiple worlds.
	/// </summary>
	public class SharpCraft
	{
		/// <summary>
		/// The currently supported version of the Minecraft protocol.
		/// </summary>
		public const int ProtocolVersion = 29;

		private static readonly string SettingsFile =
			Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SharpCraft", "settings.yml");

		private readonly Settings _settings;
		private TcpListener _listener;

		/// <summary>
		/// Creates a new instance and initializes the settings.
		/// </summary>
		/// <param name="fileName">Full path to settings file.</param>
		public SharpCraft(string fileName = null)
		{
			YamlSerializer yaml = YamlSerializer.Create(typeof (Settings));
			using (var settings = new StreamReader(fileName ?? SettingsFile))
			{
				_settings = yaml.Deserialize(settings) as Settings;
			}
		}

		/// <summary>
		/// The map that is hosted by this server.
		/// </summary>
		public Map Map { get; set; }

		/// <summary>
		/// Gets the list of currently connected clients.
		/// </summary>
		public List<Client> Clients { get; private set; }

		/// <summary>
		/// Starts the server instance. Optionally specify the local end point to be used for incoming connections.
		/// </summary>
		/// <param name="local">End point to bind on. If not specified default will be used.</param>
		public void Start(IPEndPoint local = null)
		{
			IPEndPoint ep = local ?? new IPEndPoint(IPAddress.Parse("0.0.0.0"), _settings.Port);

			_listener = new TcpListener(ep);
			_listener.Start();
		}
	}
}