using System;

namespace SharpCraft.Common
{
	/// <summary>
	/// Represents a point in 3D space.
	/// </summary>
	public class Vector3 : IEquatable<Vector3>
	{
		internal double X;
		internal double Y;
		internal double Z;

		/// <summary>
		/// Initializes a new instance of the <see cref="Vector3" /> class with all coordinates equalling the value..
		/// </summary>
		/// <param name="value">The value for all coordinates.</param>
		public Vector3(double value)
		{
			X = Y = Z = value;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Vector3" /> class with each coordinate.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="z">The z coordinate.</param>
		public Vector3(double x, double y, double z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Vector3" /> class from another.
		/// </summary>
		/// <param name="other">The other Vector3.</param>
		public Vector3(Vector3 other)
		{
			X = other.X;
			Y = other.Y;
			Z = other.Z;
		}

		#region Properties

		/// <summary>
		/// Gets a zeroed vector.
		/// </summary>
		public static Vector3 Zero
		{
			get { return new Vector3(0, 0, 0); }
		}

		/// <summary>
		/// Gets a vector with all ones.
		/// </summary>
		public static Vector3 One
		{
			get { return new Vector3(1, 1, 1); }
		}

		/// <summary>
		/// Gets the forward facing vector.
		/// </summary>
		public static Vector3 Forward
		{
			get { return new Vector3(0, 0, 1); }
		}

		/// <summary>
		/// Gets the backward facing vector.
		/// </summary>
		public static Vector3 Backward
		{
			get { return new Vector3(0, 0, -1); }
		}

		/// <summary>
		/// Gets the upward facing vector.
		/// </summary>
		public static Vector3 Up
		{
			get { return new Vector3(0, 1, 0); }
		}

		/// <summary>
		/// Gets the downward facing vector.
		/// </summary>
		public static Vector3 Down
		{
			get { return new Vector3(0, -1, 0); }
		}

		/// <summary>
		/// Gets the left facing vector.
		/// </summary>
		public static Vector3 Left
		{
			get { return new Vector3(-1, 0, 0); }
		}

		/// <summary>
		/// Gets the right facing vector.
		/// </summary>
		public static Vector3 Right
		{
			get { return new Vector3(1, 0, 0); }
		}

		/// <summary>
		/// Gets the north facing vector.
		/// </summary>
		public static Vector3 North
		{
			get { return Backward; }
		}

		/// <summary>
		/// Gets the south facing vector.
		/// </summary>
		public static Vector3 South
		{
			get { return Forward; }
		}

		/// <summary>
		/// Gets the east facing vector.
		/// </summary>
		public static Vector3 East
		{
			get { return Right; }
		}

		/// <summary>
		/// Gets the west facing vector.
		/// </summary>
		public static Vector3 West
		{
			get { return Left; }
		}

		#endregion

		#region IEquatable<Vector3> Members

		public bool Equals(Vector3 other)
		{
			if (other == null)
				return false;

			return other.X.Equals(X) && other.Y.Equals(Y) && other.Z.Equals(Z);
		}

		#endregion

		/// <summary>
		/// Clones this instance.
		/// </summary>
		/// <returns>A copy of the Vector3.</returns>
		public Vector3 Clone()
		{
			return (Vector3) MemberwiseClone();
		}

		/// <summary>
		/// Floors this instance.
		/// </summary>
		/// <returns></returns>
		public Vector3 Floor()
		{
			return new Vector3(X, Y, Z);
		}

		/// <summary>
		/// Adds two vectors.
		/// </summary>
		/// <param name="a">A.</param>
		/// <param name="b">The b.</param>
		/// <returns></returns>
		public static Vector3 operator +(Vector3 a, Vector3 b)
		{
			return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
		}
	}
}