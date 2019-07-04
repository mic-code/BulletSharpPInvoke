using System;
using BulletSharp.Math;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	public class BuSimplex1To4 : PolyhedralConvexAabbCachingShape
	{
		internal BuSimplex1To4(ConstructionInfo info)
		{
		}

		public BuSimplex1To4()
		{
			IntPtr native = btBU_Simplex1to4_new();
			InitializeCollisionShape(native);
		}

		public BuSimplex1To4(Vector3d pt0)
		{
			IntPtr native = btBU_Simplex1to4_new2(ref pt0);
			InitializeCollisionShape(native);
		}

		public BuSimplex1To4(Vector3d pt0, Vector3d pt1)
		{
			IntPtr native = btBU_Simplex1to4_new3(ref pt0, ref pt1);
			InitializeCollisionShape(native);
		}

		public BuSimplex1To4(Vector3d pt0, Vector3d pt1, Vector3d pt2)
		{
			IntPtr native = btBU_Simplex1to4_new4(ref pt0, ref pt1, ref pt2);
			InitializeCollisionShape(native);
		}

		public BuSimplex1To4(Vector3d pt0, Vector3d pt1, Vector3d pt2, Vector3d pt3)
		{
			IntPtr native = btBU_Simplex1to4_new5(ref pt0, ref pt1, ref pt2, ref pt3);
			InitializeCollisionShape(native);
		}

		public void AddVertexRef(ref Vector3d pt)
		{
			btBU_Simplex1to4_addVertex(Native, ref pt);
		}

		public void AddVertex(Vector3d pt)
		{
			btBU_Simplex1to4_addVertex(Native, ref pt);
		}

		public int GetIndex(int i)
		{
			return btBU_Simplex1to4_getIndex(Native, i);
		}

		public void Reset()
		{
			btBU_Simplex1to4_reset(Native);
		}
	}
}
