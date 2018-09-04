using System;
using BulletSharp.Math;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	public class BuSimplex1To4 : PolyhedralConvexAabbCachingShape
	{
		internal BuSimplex1To4(IntPtr native)
			: base(native)
		{
		}

		public BuSimplex1To4()
			: base(btBU_Simplex1to4_new())
		{
		}

		public BuSimplex1To4(Vector3d pt0)
			: base(btBU_Simplex1to4_new2(ref pt0))
		{
		}

		public BuSimplex1To4(Vector3d pt0, Vector3d pt1)
			: base(btBU_Simplex1to4_new3(ref pt0, ref pt1))
		{
		}

		public BuSimplex1To4(Vector3d pt0, Vector3d pt1, Vector3d pt2)
			: base(btBU_Simplex1to4_new4(ref pt0, ref pt1, ref pt2))
		{
		}

		public BuSimplex1To4(Vector3d pt0, Vector3d pt1, Vector3d pt2, Vector3d pt3)
			: base(btBU_Simplex1to4_new5(ref pt0, ref pt1, ref pt2, ref pt3))
		{
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
