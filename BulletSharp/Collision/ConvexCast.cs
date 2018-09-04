using System;
using BulletSharp.Math;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	public class ConvexCast : IDisposable
	{
		public class CastResult : IDisposable
		{
			internal IntPtr Native;

			private DebugDraw _debugDrawer;

			internal CastResult(IntPtr native)
			{
				Native = native;
			}

			public CastResult()
			{
				Native = btConvexCast_CastResult_new();
			}

			public void DebugDraw(double fraction)
			{
				btConvexCast_CastResult_DebugDraw(Native, fraction);
			}

			public void DrawCoordSystem(Matrix trans)
			{
				btConvexCast_CastResult_drawCoordSystem(Native, ref trans);
			}

			public void ReportFailure(int errNo, int numIterations)
			{
				btConvexCast_CastResult_reportFailure(Native, errNo, numIterations);
			}

			public double AllowedPenetration
			{
				get => btConvexCast_CastResult_getAllowedPenetration(Native);
				set => btConvexCast_CastResult_setAllowedPenetration(Native, value);
			}

			public DebugDraw DebugDrawer
			{
				get => _debugDrawer;
				set
				{
					_debugDrawer = value;
					btConvexCast_CastResult_setDebugDrawer(Native, value != null ? value._native : IntPtr.Zero);
				}
			}

			public double Fraction
			{
				get => btConvexCast_CastResult_getFraction(Native);
				set => btConvexCast_CastResult_setFraction(Native, value);
			}

			public Vector3d HitPoint
			{
				get
				{
					Vector3d value;
					btConvexCast_CastResult_getHitPoint(Native, out value);
					return value;
				}
				set => btConvexCast_CastResult_setHitPoint(Native, ref value);
			}

			public Matrix HitTransformA
			{
				get
				{
					Matrix value;
					btConvexCast_CastResult_getHitTransformA(Native, out value);
					return value;
				}
				set => btConvexCast_CastResult_setHitTransformA(Native, ref value);
			}

			public Matrix HitTransformB
			{
				get
				{
					Matrix value;
					btConvexCast_CastResult_getHitTransformB(Native, out value);
					return value;
				}
				set => btConvexCast_CastResult_setHitTransformB(Native, ref value);
			}

			public Vector3d Normal
			{
				get
				{
					Vector3d value;
					btConvexCast_CastResult_getNormal(Native, out value);
					return value;
				}
				set => btConvexCast_CastResult_setNormal(Native, ref value);
			}

			public void Dispose()
			{
				Dispose(true);
				GC.SuppressFinalize(this);
			}

			protected virtual void Dispose(bool disposing)
			{
				if (Native != IntPtr.Zero)
				{
					btConvexCast_CastResult_delete(Native);
					Native = IntPtr.Zero;
				}
			}

			~CastResult()
			{
				Dispose(false);
			}
		}

		internal IntPtr Native;

		internal ConvexCast(IntPtr native)
		{
			Native = native;
		}

		public bool CalcTimeOfImpact(Matrix fromA, Matrix toA, Matrix fromB, Matrix toB,
			CastResult result)
		{
			return btConvexCast_calcTimeOfImpact(Native, ref fromA, ref toA, ref fromB,
				ref toB, result.Native);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (Native != IntPtr.Zero)
			{
				btConvexCast_delete(Native);
				Native = IntPtr.Zero;
			}
		}

		~ConvexCast()
		{
			Dispose(false);
		}
	}
}
