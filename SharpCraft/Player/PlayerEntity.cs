using SharpCraft.Common;

namespace SharpCraft.Player
{
	/// <summary>
	/// Repesents the physical presence of a player in the world.
	/// </summary>
	public class PlayerEntity : Entity
	{
		private string _name;

		/// <summary>
		/// Name of the player.
		/// </summary>
		public string Name
		{
			get { return _name; }
			set
			{
				if (!Equals(_name, value))
					OnPropertyChanged("Name");
				_name = value;
			}
		}

		public override byte TypeID
		{
			get { throw new System.NotImplementedException(); }
		}

		public override Cube CollisionBox
		{
			get { throw new System.NotImplementedException(); }
		}
	}
}
