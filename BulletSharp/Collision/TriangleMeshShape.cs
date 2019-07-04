using System;
using System.Runtime.InteropServices;
using BulletSharp.Math;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	public class TriangleMeshShape : ConcaveShape
	{
		protected internal TriangleMeshShape()
		{
		}

		protected internal void InitializeMembers(StridingMeshInterface meshInterface)
		{
			MeshInterface = meshInterface;
		}

		public void LocalGetSupportingVertex(ref Vector3d vec, out Vector3d value)
		{
			btTriangleMeshShape_localGetSupportingVertex(Native, ref vec, out value);
		}

		public Vector3d LocalGetSupportingVertex(Vector3d vec)
		{
			Vector3d value;
			btTriangleMeshShape_localGetSupportingVertex(Native, ref vec, out value);
			return value;
		}

		public void LocalGetSupportingVertexWithoutMargin(ref Vector3d vec, out Vector3d value)
		{
			btTriangleMeshShape_localGetSupportingVertexWithoutMargin(Native, ref vec,
				out value);
		}

		public Vector3d LocalGetSupportingVertexWithoutMargin(Vector3d vec)
		{
			Vector3d value;
			btTriangleMeshShape_localGetSupportingVertexWithoutMargin(Native, ref vec,
				out value);
			return value;
		}

		public void RecalcLocalAabb()
		{
			btTriangleMeshShape_recalcLocalAabb(Native);
		}

		public Vector3d LocalAabbMax
		{
			get
			{
				Vector3d value;
				btTriangleMeshShape_getLocalAabbMax(Native, out value);
				return value;
			}
		}

		public Vector3d LocalAabbMin
		{
			get
			{
				Vector3d value;
				btTriangleMeshShape_getLocalAabbMin(Native, out value);
				return value;
			}
		}

		public StridingMeshInterface MeshInterface { get; private set; }
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct TriangleMeshShapeData
	{
		public CollisionShapeData CollisionShapeData;
		public StridingMeshInterfaceData MeshInterface;
		public IntPtr QuantizedFloatBvh;
		public IntPtr QuantizedDoubleBvh;
		public IntPtr TriangleInfoMap;
		public double CollisionMargin;
		public int Pad;

		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(TriangleMeshShapeData), fieldName).ToInt32(); }
	}
}
