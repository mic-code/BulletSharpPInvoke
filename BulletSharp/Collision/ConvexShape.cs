using System;
using BulletSharp.Math;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	public class ConvexShape : CollisionShape
	{
		internal ConvexShape(IntPtr native, bool preventDelete = false)
			: base(native, preventDelete)
		{
		}
		/*
		public void BatchedUnitVectorGetSupportingVertexWithoutMargin(Vector3 vectors,
			Vector3 supportVerticesOut, int numVectors)
		{
			btConvexShape_batchedUnitVectorGetSupportingVertexWithoutMargin(Native,
				vectors.Native, supportVerticesOut.Native, numVectors);
		}
		*/

		public void GetAabbNonVirtual(Matrix t, out Vector3d aabbMin, out Vector3d aabbMax)
		{
			btConvexShape_getAabbNonVirtual(Native, ref t, out aabbMin, out aabbMax);
		}

		public void GetAabbSlow(Matrix t, out Vector3d aabbMin, out Vector3d aabbMax)
		{
			btConvexShape_getAabbSlow(Native, ref t, out aabbMin, out aabbMax);
		}

		public void GetPreferredPenetrationDirection(int index, out Vector3d penetrationVector)
		{
			btConvexShape_getPreferredPenetrationDirection(Native, index, out penetrationVector);
		}

		public Vector3d LocalGetSupportingVertex(Vector3d vec)
		{
			Vector3d value;
			btConvexShape_localGetSupportingVertex(Native, ref vec, out value);
			return value;
		}

		public Vector3d LocalGetSupportingVertexWithoutMargin(Vector3d vec)
		{
			Vector3d value;
			btConvexShape_localGetSupportingVertexWithoutMargin(Native, ref vec,
				out value);
			return value;
		}

		public Vector3d LocalGetSupportVertexNonVirtual(Vector3d vec)
		{
			Vector3d value;
			btConvexShape_localGetSupportVertexNonVirtual(Native, ref vec, out value);
			return value;
		}

		public Vector3d LocalGetSupportVertexWithoutMarginNonVirtual(Vector3d vec)
		{
			Vector3d value;
			btConvexShape_localGetSupportVertexWithoutMarginNonVirtual(Native, ref vec,
				out value);
			return value;
		}

		public void ProjectRef(ref Matrix trans, ref Vector3d dir, out double minProj, out double maxProj,
			out Vector3d witnesPtMin, out Vector3d witnesPtMax)
		{
			btConvexShape_project(Native, ref trans, ref dir, out minProj, out maxProj,
				out witnesPtMin, out witnesPtMax);
		}

		public void Project(Matrix trans, Vector3d dir, out double minProj, out double maxProj,
			out Vector3d witnesPtMin, out Vector3d witnesPtMax)
		{
			btConvexShape_project(Native, ref trans, ref dir, out minProj, out maxProj,
				out witnesPtMin, out witnesPtMax);
		}

		public double MarginNonVirtual => btConvexShape_getMarginNonVirtual(Native);

		public int NumPreferredPenetrationDirections => btConvexShape_getNumPreferredPenetrationDirections(Native);
	}
}
