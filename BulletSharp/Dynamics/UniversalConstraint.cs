using BulletSharp.Math;
using System;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	public class UniversalConstraint : Generic6DofConstraint
	{
		public UniversalConstraint(RigidBody rigidBodyA, RigidBody rigidBodyB, Vector3d anchor,
			Vector3d axis1, Vector3d axis2)
		{
			IntPtr native = btUniversalConstraint_new(rigidBodyA.Native, rigidBodyB.Native,
				ref anchor, ref axis1, ref axis2);
			InitializeUserOwned(native);
			InitializeMembers(rigidBodyA, rigidBodyB);
		}

		public void SetLowerLimit(double ang1min, double ang2min)
		{
			btUniversalConstraint_setLowerLimit(Native, ang1min, ang2min);
		}

		public void SetUpperLimit(double ang1max, double ang2max)
		{
			btUniversalConstraint_setUpperLimit(Native, ang1max, ang2max);
		}

		public Vector3d Anchor
		{
			get
			{
				Vector3d value;
				btUniversalConstraint_getAnchor(Native, out value);
				return value;
			}
		}

		public Vector3d Anchor2
		{
			get
			{
				Vector3d value;
				btUniversalConstraint_getAnchor2(Native, out value);
				return value;
			}
		}

		public double Angle1 => btUniversalConstraint_getAngle1(Native);

		public double Angle2 => btUniversalConstraint_getAngle2(Native);

		public Vector3d Axis1
		{
			get
			{
				Vector3d value;
				btUniversalConstraint_getAxis1(Native, out value);
				return value;
			}
		}

		public Vector3d Axis2
		{
			get
			{
				Vector3d value;
				btUniversalConstraint_getAxis2(Native, out value);
				return value;
			}
		}
	}
}
