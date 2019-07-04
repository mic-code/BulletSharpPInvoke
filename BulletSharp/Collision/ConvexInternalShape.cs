using System.Runtime.InteropServices;
using BulletSharp.Math;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	public abstract class ConvexInternalShape : ConvexShape
	{
		protected internal ConvexInternalShape()
		{
		}

		public void SetSafeMargin(double minDimension, double defaultMarginMultiplier = 0.1f)
		{
			btConvexInternalShape_setSafeMargin(Native, minDimension, defaultMarginMultiplier);
		}

		public void SetSafeMarginRef(ref Vector3d halfExtents, double defaultMarginMultiplier = 0.1f)
		{
			btConvexInternalShape_setSafeMargin2(Native, ref halfExtents, defaultMarginMultiplier);
		}

		public void SetSafeMargin(Vector3d halfExtents, double defaultMarginMultiplier = 0.1f)
		{
			btConvexInternalShape_setSafeMargin2(Native, ref halfExtents, defaultMarginMultiplier);
		}

		public Vector3d ImplicitShapeDimensions
		{
			get
			{
				Vector3d value;
				btConvexInternalShape_getImplicitShapeDimensions(Native, out value);
				return value;
			}
			set { btConvexInternalShape_setImplicitShapeDimensions(Native, ref value); }
		}

		public Vector3d LocalScalingNV
		{
			get
			{
				Vector3d value;
				btConvexInternalShape_getLocalScalingNV(Native, out value);
				return value;
			}
		}

		public double MarginNV => btConvexInternalShape_getMarginNV(Native);
	}

	public abstract class ConvexInternalAabbCachingShape : ConvexInternalShape
	{
		protected internal ConvexInternalAabbCachingShape()
		{
		}

		public void RecalcLocalAabb()
		{
			btConvexInternalAabbCachingShape_recalcLocalAabb(Native);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct ConvexInternalShapeData
	{
		public CollisionShapeData CollisionShapeData;
		public Vector3FloatData LocalScaling;
		public Vector3FloatData ImplicitShapeDimensions;
		public float CollisionMargin;
		public int Padding;

		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(ConvexInternalShapeData), fieldName).ToInt32(); }
	}
}
