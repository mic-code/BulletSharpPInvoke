using BulletSharp.Math;
using System;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	public class MultiBodySliderConstraint : MultiBodyConstraint
	{
		public MultiBodySliderConstraint(MultiBody body, int link, RigidBody bodyB,
			Vector3d pivotInA, Vector3d pivotInB, Matrix frameInA, Matrix frameInB, Vector3d jointAxis)
		{
			IntPtr native = btMultiBodySliderConstraint_new(body.Native, link, bodyB.Native,
				ref pivotInA, ref pivotInB, ref frameInA, ref frameInB, ref jointAxis);
			InitializeUserOwned(native);
			InitializeMembers(body, null);
		}

		public MultiBodySliderConstraint(MultiBody bodyA, int linkA, MultiBody bodyB,
			int linkB, Vector3d pivotInA, Vector3d pivotInB, Matrix frameInA, Matrix frameInB,
			Vector3d jointAxis)
		{
			IntPtr native = btMultiBodySliderConstraint_new2(bodyA.Native, linkA, bodyB.Native,
				linkB, ref pivotInA, ref pivotInB, ref frameInA, ref frameInB, ref jointAxis);
			InitializeUserOwned(native);
			InitializeMembers(bodyA, bodyB);
		}

		public Matrix FrameInA
		{
			get
			{
				Matrix value;
				btMultiBodySliderConstraint_getFrameInA(Native, out value);
				return value;
			}
			set => btMultiBodySliderConstraint_setFrameInA(Native, ref value);
		}

		public Matrix FrameInB
		{
			get
			{
				Matrix value;
				btMultiBodySliderConstraint_getFrameInB(Native, out value);
				return value;
			}
			set => btMultiBodySliderConstraint_setFrameInB(Native, ref value);
		}

		public Vector3d JointAxis
		{
			get
			{
				Vector3d value;
				btMultiBodySliderConstraint_getJointAxis(Native, out value);
				return value;
			}
			set => btMultiBodySliderConstraint_setJointAxis(Native, ref value);
		}

		public Vector3d PivotInA
		{
			get
			{
				Vector3d value;
				btMultiBodySliderConstraint_getPivotInA(Native, out value);
				return value;
			}
			set => btMultiBodySliderConstraint_setPivotInA(Native, ref value);
		}

		public Vector3d PivotInB
		{
			get
			{
				Vector3d value;
				btMultiBodySliderConstraint_getPivotInB(Native, out value);
				return value;
			}
			set => btMultiBodySliderConstraint_setPivotInB(Native, ref value);
		}
	}
}
