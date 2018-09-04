using BulletSharp.Math;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	public class ScaledBvhTriangleMeshShape : ConcaveShape
	{
		public ScaledBvhTriangleMeshShape(BvhTriangleMeshShape childShape, Vector3d localScaling)
			: base(btScaledBvhTriangleMeshShape_new(childShape.Native, ref localScaling))
		{
			ChildShape = childShape;
		}

		public BvhTriangleMeshShape ChildShape { get; }
	}
}
