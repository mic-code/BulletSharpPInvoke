using System;
using System.Runtime.InteropServices;
using System.Security;
using BulletSharp.Math;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	public abstract class TriangleCallback : BulletDisposableObject
	{
		[UnmanagedFunctionPointer(BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
		private delegate void ProcessTriangleDelegate(IntPtr triangle, int partId, int triangleIndex);

		private readonly ProcessTriangleDelegate _processTriangle;

		public TriangleCallback()
		{
			_processTriangle = new ProcessTriangleDelegate(ProcessTriangleUnmanaged);

			IntPtr native = btTriangleCallbackWrapper_new(
				Marshal.GetFunctionPointerForDelegate(_processTriangle));
			InitializeUserOwned(native);
		}

		private void ProcessTriangleUnmanaged(IntPtr triangle, int partId, int triangleIndex)
		{
			double[] triangleData = new double[11];
			Marshal.Copy(triangle, triangleData, 0, 11);
			Vector3d p0 = new Vector3d(triangleData[0], triangleData[1], triangleData[2]);
			Vector3d p1 = new Vector3d(triangleData[4], triangleData[5], triangleData[6]);
			Vector3d p2 = new Vector3d(triangleData[8], triangleData[9], triangleData[10]);
			ProcessTriangle(ref p0, ref p1, ref p2, partId, triangleIndex);
		}

		public abstract void ProcessTriangle(ref Vector3d point0, ref Vector3d point1, ref Vector3d point2, int partId, int triangleIndex);

		protected override void Dispose(bool disposing)
		{
			btTriangleCallback_delete(Native);
		}
}

	public abstract class InternalTriangleIndexCallback : BulletDisposableObject
	{
		[UnmanagedFunctionPointer(BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void InternalProcessTriangleIndexDelegate(IntPtr triangle, int partId, int triangleIndex);

		private readonly InternalProcessTriangleIndexDelegate _internalProcessTriangleIndex;

		internal InternalTriangleIndexCallback()
		{
			_internalProcessTriangleIndex = new InternalProcessTriangleIndexDelegate(InternalProcessTriangleIndexUnmanaged);

			IntPtr native = btInternalTriangleIndexCallbackWrapper_new(
				Marshal.GetFunctionPointerForDelegate(_internalProcessTriangleIndex));
			InitializeUserOwned(native);
		}

		private void InternalProcessTriangleIndexUnmanaged(IntPtr triangle, int partId, int triangleIndex)
		{
			double[] triangleData = new double[11];
			Marshal.Copy(triangle, triangleData, 0, 11);
			Vector3d p0 = new Vector3d(triangleData[0], triangleData[1], triangleData[2]);
			Vector3d p1 = new Vector3d(triangleData[4], triangleData[5], triangleData[6]);
			Vector3d p2 = new Vector3d(triangleData[8], triangleData[9], triangleData[10]);
			InternalProcessTriangleIndex(ref p0, ref p1, ref p2, partId, triangleIndex);
		}

		public abstract void InternalProcessTriangleIndex(ref Vector3d point0, ref Vector3d point1, ref Vector3d point2, int partId, int triangleIndex);

		protected override void Dispose(bool disposing)
		{
			btInternalTriangleIndexCallback_delete(Native);
		}
	}
}
