using System;

namespace SharpCraft.Common
{
	/// <summary>
	/// Represents a cube in 3D space.
	/// </summary>
	public class Cube : IEquatable<Cube>
	{
		/// <summary>
		/// A cube with a physical size of (1,1,1) and a location at (0,0,0).
		/// </summary>
		public static Cube Default = new Cube();

		/// <summary>
		/// Initializes a new instance of the <see cref="Cube" /> class.
		/// </summary>
		public Cube()
		{
			Location = Vector3.Zero;
			Size = Vector3.One;
		}

		/// <summary>
		/// Gets or sets the location of the cube.
		/// </summary>
		/// <value>
		/// The current location.
		/// </value>
		public Vector3 Location { get; set; }
		/// <summary>
		/// Gets or sets the size of the cube.
		/// </summary>
		/// <value>
		/// The cubes size.
		/// </value>
		public Vector3 Size { get; set; }

		#region IEquatable<Cube> Members

		public bool Equals(Cube other)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}