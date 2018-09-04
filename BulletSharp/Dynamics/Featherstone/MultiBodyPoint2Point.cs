using System;
using BulletSharp.Math;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	public class MultiBodyPoint2Point : MultiBodyConstraint
	{
		public MultiBodyPoint2Point(MultiBody body, int link, RigidBody bodyB, Vector3d pivotInA,
			Vector3d pivotInB)
			: base(btMultiBodyPoint2Point_new(body.Native, link, bodyB != null ? bodyB.Native : IntPtr.Zero,
				ref pivotInA, ref pivotInB), body, null)
		{
		}

		public MultiBodyPoint2Point(MultiBody bodyA, int linkA, MultiBody bodyB,
			int linkB, Vector3d pivotInA, Vector3d pivotInB)
			: base(btMultiBodyPoint2Point_new2(bodyA.Native, linkA, bodyB.Native,
				linkB, ref pivotInA, ref pivotInB), bodyA, bodyB)
		{
		}

		public Vector3d PivotInB
		{
			get
			{
				Vector3d value;
				btMultiBodyPoint2Point_getPivotInB(Native, out value);
				return value;
			}
			set => btMultiBodyPoint2Point_setPivotInB(Native, ref value);
		}
	}
}
