using BulletSharp.Math;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	public class MultiBodyFixedConstraint : MultiBodyConstraint
	{
		public MultiBodyFixedConstraint(MultiBody body, int link, RigidBody bodyB,
			Vector3d pivotInA, Vector3d pivotInB, Matrix frameInA, Matrix frameInB)
			: base(btMultiBodyFixedConstraint_new(body.Native, link, bodyB.Native,
				ref pivotInA, ref pivotInB, ref frameInA, ref frameInB), body, null)
		{
		}

		public MultiBodyFixedConstraint(MultiBody bodyA, int linkA, MultiBody bodyB,
			int linkB, Vector3d pivotInA, Vector3d pivotInB, Matrix frameInA, Matrix frameInB)
			: base(btMultiBodyFixedConstraint_new2(bodyA.Native, linkA, bodyB.Native,
				linkB, ref pivotInA, ref pivotInB, ref frameInA, ref frameInB), bodyA, bodyB)
		{
		}

		public Matrix FrameInA
		{
			get
			{
				Matrix value;
				btMultiBodyFixedConstraint_getFrameInA(Native, out value);
				return value;
			}
			set => btMultiBodyFixedConstraint_setFrameInA(Native, ref value);
		}

		public Matrix FrameInB
		{
			get
			{
				Matrix value;
				btMultiBodyFixedConstraint_getFrameInB(Native, out value);
				return value;
			}
			set => btMultiBodyFixedConstraint_setFrameInB(Native, ref value);
		}

		public Vector3d PivotInA
		{
			get
			{
				Vector3d value;
				btMultiBodyFixedConstraint_getPivotInA(Native, out value);
				return value;
			}
			set => btMultiBodyFixedConstraint_setPivotInA(Native, ref value);
		}

		public Vector3d PivotInB
		{
			get
			{
				Vector3d value;
				btMultiBodyFixedConstraint_getPivotInB(Native, out value);
				return value;
			}
			set => btMultiBodyFixedConstraint_setPivotInB(Native, ref value);
		}
	}
}
