using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using SharpCraft.Net;
using SharpCraft.World;

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

		private TcpListener _listener;

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
			IPEndPoint ep = local ?? new IPEndPoint(IPAddress.Parse("0.0.0.0"), 25575);

			_listener = new TcpListener(ep);
			_listener.Start();
		}
	}
}