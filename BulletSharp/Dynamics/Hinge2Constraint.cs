using BulletSharp.Math;
using System;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	public class Hinge2Constraint : Generic6DofSpring2Constraint
	{
		public Hinge2Constraint(RigidBody rigidBodyA, RigidBody rigidBodyB, Vector3d anchor,
			Vector3d axis1, Vector3d axis2)
		{
			IntPtr native = btHinge2Constraint_new(rigidBodyA.Native, rigidBodyB.Native,
				ref anchor, ref axis1, ref axis2);
			InitializeUserOwned(native);
			InitializeMembers(rigidBodyA, rigidBodyB);
		}

		public void SetLowerLimit(double ang1min)
		{
			btHinge2Constraint_setLowerLimit(Native, ang1min);
		}

		public void SetUpperLimit(double ang1max)
		{
			btHinge2Constraint_setUpperLimit(Native, ang1max);
		}

		public Vector3d Anchor
		{
			get
			{
				Vector3d value;
				btHinge2Constraint_getAnchor(Native, out value);
				return value;
			}
		}

		public Vector3d Anchor2
		{
			get
			{
				Vector3d value;
				btHinge2Constraint_getAnchor2(Native, out value);
				return value;
			}
		}

		public double Angle1 => btHinge2Constraint_getAngle1(Native);

		public double Angle2 => btHinge2Constraint_getAngle2(Native);

		public Vector3d Axis1
		{
			get
			{
				Vector3d value;
				btHinge2Constraint_getAxis1(Native, out value);
				return value;
			}
		}

		public Vector3d Axis2
		{
			get
			{
				Vector3d value;
				btHinge2Constraint_getAxis2(Native, out value);
				return value;
			}
		}
	}
}
