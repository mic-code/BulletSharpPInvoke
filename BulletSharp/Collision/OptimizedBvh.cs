using System;
using BulletSharp.Math;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	public class OptimizedBvh : QuantizedBvh
	{
		internal OptimizedBvh(IntPtr native)
			: base(ConstructionInfo.Null)
		{
			InitializeSubObject(native, this);
		}

		internal OptimizedBvh(IntPtr native, BulletObject owner)
			: base(ConstructionInfo.Null)
		{
			InitializeSubObject(native, owner);
		}

		public OptimizedBvh()
			: base(ConstructionInfo.Null)
		{
			IntPtr native = btOptimizedBvh_new();
			InitializeUserOwned(native);
		}

		public void Build(StridingMeshInterface triangles, bool useQuantizedAabbCompression,
			Vector3d bvhAabbMin, Vector3d bvhAabbMax)
		{
			btOptimizedBvh_build(Native, triangles.Native, useQuantizedAabbCompression,
				ref bvhAabbMin, ref bvhAabbMax);
		}

		public static OptimizedBvh DeSerializeInPlace(IntPtr alignedDataBuffer, uint dataBufferSize,
			bool swapEndian)
		{
			return new OptimizedBvh(btOptimizedBvh_deSerializeInPlace(alignedDataBuffer, dataBufferSize,
				swapEndian));
		}

		public void Refit(StridingMeshInterface triangles, Vector3d aabbMin, Vector3d aabbMax)
		{
			btOptimizedBvh_refit(Native, triangles.Native, ref aabbMin, ref aabbMax);
		}

		public void RefitPartial(StridingMeshInterface triangles, Vector3d aabbMin,
			Vector3d aabbMax)
		{
			btOptimizedBvh_refitPartial(Native, triangles.Native, ref aabbMin,
				ref aabbMax);
		}

		public bool SerializeInPlace(IntPtr alignedDataBuffer, uint dataBufferSize,
			bool swapEndian)
		{
			return btOptimizedBvh_serializeInPlace(Native, alignedDataBuffer, dataBufferSize,
				swapEndian);
		}

		public void UpdateBvhNodes(StridingMeshInterface meshInterface, int firstNode,
			int endNode, int index)
		{
			btOptimizedBvh_updateBvhNodes(Native, meshInterface.Native, firstNode,
				endNode, index);
		}
	}
}
