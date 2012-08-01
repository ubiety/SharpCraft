using System.ComponentModel;

namespace SharpCraft.Common
{
	/// <summary>
	/// Represents a generic entity.
	/// </summary>
	public abstract class Entity : INotifyPropertyChanged
	{
		private Vector3 _location;
		private Vector3 _rotation;
		private Vector3 _velocity;

		protected Entity(Vector3 location = null)
		{
			_location = location ?? Vector3.Zero;
			_rotation = Vector3.Zero;
			_velocity = Vector3.Zero;
		}

		/// <summary>
		/// Is the entity on the ground?
		/// </summary>
		/// <value>
		///   <c>true</c> if [on ground]; otherwise, <c>false</c>.
		/// </value>
		public bool OnGround { get; set; }

		/// <summary>
		/// How long the entity will spend on fire.
		/// </summary>
		/// <value>
		/// The time on fire.
		/// </value>
		public short TimeOnFire { get; set; }

		/// <summary>
		/// Gets or sets the ID.
		/// </summary>
		/// <value>
		/// The ID.
		/// </value>
		public int ID { get; set; }

		/// <summary>
		/// Type this entity represents.
		/// </summary>
		/// <value>
		/// The type ID.
		/// </value>
		public abstract byte TypeID { get; }

		/// <summary>
		/// The collision box of the entity.
		/// </summary>
		/// <value>
		/// The collision box.
		/// </value>
		public abstract Cube CollisionBox { get; }

		/// <summary>
		/// Does this entity have gravity.
		/// </summary>
		/// <value>
		///   <c>true</c> if gravity; otherwise, <c>false</c>.
		/// </value>
		public virtual bool Gravity
		{
			get { return true; }
		}


		/// <summary>
		/// Previous location of the entity.
		/// </summary>
		public Vector3 OldLocation { get; set; }

		/// <summary>
		/// Current location of the entity.
		/// </summary>
		public Vector3 Location
		{
			get { return _location; }
			set
			{
				if (!Equals(_velocity, value))
				{
					OldLocation = _location;
					OnPropertyChanged("Location");
				}
				_location = value;
			}
		}

		/// <summary>
		/// Velocity of the entity.
		/// </summary>
		public Vector3 Velocity
		{
			get { return _velocity; }
			set
			{
				if (!Equals(_velocity, value))
					OnPropertyChanged("Velocity");
				_velocity = value;
			}
		}

		#region INotifyPropertyChanged Members

		/// <summary>
		/// Occurs when an entity property changes.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}