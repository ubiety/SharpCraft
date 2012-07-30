using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using SharpCraft.Net.Packets;

namespace SharpCraft.Net
{
	/// <summary>
	/// Represents the client connected to the server.
	/// </summary>
	public class Client
	{
		/// <summary>
		/// Creates a new instance of client with the optional TcpClient.
		/// </summary>
		/// <param name="client">TcpClient of the connecting entity.</param>
		public Client(TcpClient client = null)
		{
			TcpClient = client;
			PacketQueue = new Queue<Packet>();
			LoggedIn = false;
			if (client != null) ClientEndPoint = client.Client.RemoteEndPoint;
			Tags = new Dictionary<string, object>();
			PacketHistory = new Queue<Packet>(10);
		}

		public TcpClient TcpClient { get; set; }
		public Queue<Packet> PacketQueue { get; set; }
		public Queue<Packet> PacketHistory { get; set; }
		public bool LoggedIn { get; set; }
		public EndPoint ClientEndPoint { get; set; }
		public Dictionary<string, object> Tags { get; set; }
	}
}