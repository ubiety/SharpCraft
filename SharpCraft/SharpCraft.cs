using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using SharpCraft.Net;
using SharpCraft.Net.Packets;
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

		private const int TickTime = 50;

		private static readonly string SettingsFile =
			Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SharpCraft", "settings.yml");

		private static TcpListener _listener;
		private static Timer _network;
		private static Timer _ticks;
		private static readonly object QueueLock = new object();

		private static int _keepAliveTicks;
		private readonly Settings _settings;

		/// <summary>
		/// Creates a new instance and initializes the settings.
		/// </summary>
		/// <param name="fileName">Full path to settings file.</param>
		public SharpCraft(string fileName = null)
		{
			var yaml = new YamlSerializer<Settings>();
			using (var settings = new StreamReader(fileName ?? SettingsFile))
			{
				_settings = yaml.Deserialize(settings);
			}
		}

		/// <summary>
		/// The map that is hosted by this server.
		/// </summary>
		public Map Map { get; set; }

		/// <summary>
		/// Gets the list of currently connected clients.
		/// </summary>
		public static List<Client> Clients { get; private set; }

		/// <summary>
		/// Starts the server instance. Optionally specify the local end point to be used for incoming connections.
		/// </summary>
		/// <param name="local">End point to bind on. If not specified default will be used.</param>
		public void Start(IPEndPoint local = null)
		{
			IPEndPoint ep = local ?? new IPEndPoint(IPAddress.Parse("0.0.0.0"), _settings.Port);

			_listener = new TcpListener(ep);
			_listener.Start();

			_network = new Timer(DoNetwork, null, TickTime, Timeout.Infinite);
			_ticks = new Timer(DoTicks, null, TickTime, Timeout.Infinite);
		}

		/// <summary>
		/// Stops the server instance.
		/// </summary>
		public void Stop()
		{
			try
			{
				_listener.Stop();
			}
			finally
			{
				if (_network != null)
					_network.Dispose();

				if (_ticks != null)
					_ticks.Dispose();

				_ticks = null;
				_network = null;
				_listener = null;
			}
		}

		private static IEnumerable<Client> GetLoggedInClients()
		{
			return new List<Client>(from c in Clients where c.LoggedIn select c);
		}

		private static void DoTicks(object state)
		{
			lock (QueueLock)
			{
				_keepAliveTicks++;
				if (_keepAliveTicks == 50)
				{
					var keepAlive = new KeepAlive();
					foreach (Client client in GetLoggedInClients())
					{
						client.PacketQueue.Enqueue(keepAlive);
					}

					_keepAliveTicks = 0;
				}
			}
		}

		private static void DoNetwork(object state)
		{
			try
			{
				if (_listener.Pending())
				{
					var client = new Client(_listener.AcceptTcpClient()) {TcpClient = {NoDelay = true, SendBufferSize = 40960}};
					Clients.Add(client);
				}
				if (Clients.Count == 0)
					return;
				var remainingClients = new List<Client>();
				foreach (Client client in Clients)
				{
					if (client.TcpClient.Connected)
					{
						remainingClients.Add(client);
					}
				}
			}
			finally
			{
				_network = new Timer(DoNetwork, null, TickTime, Timeout.Infinite);
			}
		}
	}
}