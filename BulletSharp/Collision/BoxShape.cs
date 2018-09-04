using BulletSharp.Math;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	public class BoxShape : PolyhedralConvexShape
	{
		public BoxShape(Vector3d boxHalfExtents)
			: base(btBoxShape_new(ref boxHalfExtents))
		{
		}

		public BoxShape(double boxHalfExtent)
			: base(btBoxShape_new2(boxHalfExtent))
		{
		}

		public BoxShape(double boxHalfExtentX, double boxHalfExtentY, double boxHalfExtentZ)
			: base(btBoxShape_new3(boxHalfExtentX, boxHalfExtentY, boxHalfExtentZ))
		{
		}

		public void GetPlaneEquation(out Vector4 plane, int i)
		{
			btBoxShape_getPlaneEquation(Native, out plane, i);
		}

		public Vector3d HalfExtentsWithMargin
		{
			get
			{
				Vector3d value;
				btBoxShape_getHalfExtentsWithMargin(Native, out value);
				return value;
			}
		}

		public Vector3d HalfExtentsWithoutMargin
		{
			get
			{
				Vector3d value;
				btBoxShape_getHalfExtentsWithoutMargin(Native, out value);
				return value;
			}
		}
	}
}
