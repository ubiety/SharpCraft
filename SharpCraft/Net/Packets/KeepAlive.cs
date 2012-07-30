using System;

namespace SharpCraft.Net.Packets
{
	public class KeepAlive : Packet
	{
		private readonly int _keepAlive;
		private static readonly Random Rand = new Random();
		private static readonly byte[] _payload = new byte[] { (byte)PacketID.KeepAlive, 0, 0, 0, 0};

		public KeepAlive(int keepAlive = 0)
		{
			_keepAlive = keepAlive > 0 ? keepAlive : Rand.Next();
		}

		public override PacketID PacketID
		{
			get { return PacketID.KeepAlive; }
		}

		public override int Length
		{
			get { return 5; }
		}

		public override byte[] Payload
		{
			get
			{
				Array.Copy(IntToByte(_keepAlive), 0, _payload, 1, 4);
				return _payload;
			}
		}
	}
}
