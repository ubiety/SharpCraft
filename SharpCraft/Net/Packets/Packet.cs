using System;
using System.Net;

namespace SharpCraft.Net.Packets
{
	public abstract class Packet
	{
		public abstract PacketID PacketID { get; }
		public abstract int Length { get; }
		public abstract byte[] Payload { get; }

		public static byte[] IntToByte(int i)
		{
			return BitConverter.GetBytes(IPAddress.HostToNetworkOrder(i));
		}
	}
}
