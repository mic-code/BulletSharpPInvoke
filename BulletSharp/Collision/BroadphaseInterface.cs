using System;
using System.Runtime.InteropServices;
using System.Security;
using BulletSharp.Math;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	public abstract class BroadphaseAabbCallback : BulletDisposableObject
	{
		[UnmanagedFunctionPointer(BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
		internal delegate bool ProcessUnmanagedDelegate(IntPtr proxy);

		internal ProcessUnmanagedDelegate _process;

		internal BroadphaseAabbCallback(ConstructionInfo info)
		{
			_process = ProcessUnmanaged;
		}

		protected BroadphaseAabbCallback()
		{
			_process = ProcessUnmanaged;
			IntPtr native = btBroadphaseAabbCallbackWrapper_new(
				Marshal.GetFunctionPointerForDelegate(_process));
			InitializeUserOwned(native);
		}

		private bool ProcessUnmanaged(IntPtr proxy)
		{
			return Process(BroadphaseProxy.GetManaged(proxy));
		}

		public abstract bool Process(BroadphaseProxy proxy);

		protected override void Dispose(bool disposing)
		{
			btBroadphaseAabbCallback_delete(Native);
		}
	}

	public abstract class BroadphaseRayCallback : BroadphaseAabbCallback
	{
		private UIntArray _signs;

		protected BroadphaseRayCallback()
			: base(ConstructionInfo.Null)
		{
			IntPtr native = btBroadphaseRayCallbackWrapper_new(
				Marshal.GetFunctionPointerForDelegate(_process));
			InitializeUserOwned(native);
		}

		public double LambdaMax
		{
			get => btBroadphaseRayCallback_getLambda_max(Native);
			set => btBroadphaseRayCallback_setLambda_max(Native, value);
		}

		public Vector3d RayDirectionInverse
		{
			get
			{
				Vector3d value;
				btBroadphaseRayCallback_getRayDirectionInverse(Native, out value);
				return value;
			}
			set => btBroadphaseRayCallback_setRayDirectionInverse(Native, ref value);
		}

		public UIntArray Signs
		{
			get
			{
				if (_signs == null)
				{
					_signs = new UIntArray(btBroadphaseRayCallback_getSigns(Native), 3);
				}
				return _signs;
			}
		}
	}

	public abstract class BroadphaseInterface : BulletDisposableObject
	{
		protected OverlappingPairCache _overlappingPairCache;

		protected internal BroadphaseInterface()
		{
		}

		protected internal void InitializeMembers(OverlappingPairCache overlappingPairCache)
		{
			_overlappingPairCache = overlappingPairCache;
		}

		public void AabbTestRef(ref Vector3d aabbMin, ref Vector3d aabbMax, BroadphaseAabbCallback callback)
		{
			btBroadphaseInterface_aabbTest(Native, ref aabbMin, ref aabbMax, callback.Native);
		}

		public void AabbTest(Vector3d aabbMin, Vector3d aabbMax, BroadphaseAabbCallback callback)
		{
			btBroadphaseInterface_aabbTest(Native, ref aabbMin, ref aabbMax, callback.Native);
		}

		public void CalculateOverlappingPairs(Dispatcher dispatcher)
		{
			btBroadphaseInterface_calculateOverlappingPairs(Native, dispatcher.Native);
		}

		public abstract BroadphaseProxy CreateProxy(ref Vector3d aabbMin, ref Vector3d aabbMax,
			int shapeType, IntPtr userPtr, int collisionFilterGroup, int collisionFilterMask,
			Dispatcher dispatcher);

		public void DestroyProxy(BroadphaseProxy proxy, Dispatcher dispatcher)
		{
			btBroadphaseInterface_destroyProxy(Native, proxy.Native, dispatcher.Native);
		}

		public void GetAabb(BroadphaseProxy proxy, out Vector3d aabbMin, out Vector3d aabbMax)
		{
			btBroadphaseInterface_getAabb(Native, proxy.Native, out aabbMin, out aabbMax);
		}

		public void GetBroadphaseAabb(out Vector3d aabbMin, out Vector3d aabbMax)
		{
			btBroadphaseInterface_getBroadphaseAabb(Native, out aabbMin, out aabbMax);
		}

		public void PrintStats()
		{
			btBroadphaseInterface_printStats(Native);
		}

		public void RayTestRef(ref Vector3d rayFrom, ref Vector3d rayTo, BroadphaseRayCallback rayCallback)
		{
			btBroadphaseInterface_rayTest(Native, ref rayFrom, ref rayTo, rayCallback.Native);
		}

		public void RayTest(Vector3d rayFrom, Vector3d rayTo, BroadphaseRayCallback rayCallback)
		{
			btBroadphaseInterface_rayTest(Native, ref rayFrom, ref rayTo, rayCallback.Native);
		}

		public void RayTestRef(ref Vector3d rayFrom, ref Vector3d rayTo, BroadphaseRayCallback rayCallback, ref Vector3d aabbMin, ref Vector3d aabbMax)
		{
			btBroadphaseInterface_rayTest3(Native, ref rayFrom, ref rayTo, rayCallback.Native, ref aabbMin, ref aabbMax);
		}

		public void RayTest(Vector3d rayFrom, Vector3d rayTo, BroadphaseRayCallback rayCallback,
			Vector3d aabbMin, Vector3d aabbMax)
		{
			btBroadphaseInterface_rayTest3(Native, ref rayFrom, ref rayTo, rayCallback.Native,
				ref aabbMin, ref aabbMax);
		}

		public void ResetPool(Dispatcher dispatcher)
		{
			btBroadphaseInterface_resetPool(Native, dispatcher.Native);
		}

		public void SetAabbRef(BroadphaseProxy proxy, ref Vector3d aabbMin, ref Vector3d aabbMax, Dispatcher dispatcher)
		{
			btBroadphaseInterface_setAabb(Native, proxy.Native, ref aabbMin, ref aabbMax, dispatcher.Native);
		}

		public void SetAabb(BroadphaseProxy proxy, Vector3d aabbMin, Vector3d aabbMax,
			Dispatcher dispatcher)
		{
			btBroadphaseInterface_setAabb(Native, proxy.Native, ref aabbMin, ref aabbMax,
				dispatcher.Native);
		}

		public OverlappingPairCache OverlappingPairCache => _overlappingPairCache;

		protected override void Dispose(bool disposing)
		{
			btBroadphaseInterface_delete(Native);
		}
	}
}
