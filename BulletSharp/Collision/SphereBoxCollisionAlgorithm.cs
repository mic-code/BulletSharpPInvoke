using System;
using BulletSharp.Math;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	public class SphereBoxCollisionAlgorithm : ActivatingCollisionAlgorithm
	{
		public class CreateFunc : CollisionAlgorithmCreateFunc
		{
			internal CreateFunc(IntPtr native, BulletObject owner)
				: base(ConstructionInfo.Null)
			{
				InitializeSubObject(native, owner);
			}

			public CreateFunc()
				: base(ConstructionInfo.Null)
			{
				IntPtr native = btSphereBoxCollisionAlgorithm_CreateFunc_new();
				InitializeUserOwned(native);
			}

			public override CollisionAlgorithm CreateCollisionAlgorithm(CollisionAlgorithmConstructionInfo __unnamed0, CollisionObjectWrapper body0Wrap, CollisionObjectWrapper body1Wrap)
			{
				return new SphereBoxCollisionAlgorithm(btCollisionAlgorithmCreateFunc_CreateCollisionAlgorithm(
					Native, __unnamed0.Native, body0Wrap.Native, body1Wrap.Native), __unnamed0.Dispatcher);
			}
		}

		internal SphereBoxCollisionAlgorithm(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		public SphereBoxCollisionAlgorithm(PersistentManifold mf, CollisionAlgorithmConstructionInfo ci,
			CollisionObjectWrapper body0Wrap, CollisionObjectWrapper body1Wrap, bool isSwapped)
		{
			IntPtr native = btSphereBoxCollisionAlgorithm_new(mf.Native, ci.Native, body0Wrap.Native,
				body1Wrap.Native, isSwapped);
			InitializeUserOwned(native);
		}

		public bool GetSphereDistanceRef(CollisionObjectWrapper boxObjWrap, out Vector3d v3PointOnBox,
			out Vector3d normal, out double penetrationDepth, Vector3d v3SphereCenter,
			double fRadius, double maxContactDistance)
		{
			return btSphereBoxCollisionAlgorithm_getSphereDistance(Native, boxObjWrap.Native,
				out v3PointOnBox, out normal, out penetrationDepth, ref v3SphereCenter,
				fRadius, maxContactDistance);
		}

		public bool GetSphereDistance(CollisionObjectWrapper boxObjWrap, out Vector3d v3PointOnBox,
			out Vector3d normal, out double penetrationDepth, Vector3d v3SphereCenter,
			double fRadius, double maxContactDistance)
		{
			return btSphereBoxCollisionAlgorithm_getSphereDistance(Native, boxObjWrap.Native,
				out v3PointOnBox, out normal, out penetrationDepth, ref v3SphereCenter,
				fRadius, maxContactDistance);
		}

		public double GetSpherePenetrationRef(ref Vector3d boxHalfExtent, ref Vector3d sphereRelPos,
			out Vector3d closestPoint, out Vector3d normal)
		{
			return btSphereBoxCollisionAlgorithm_getSpherePenetration(Native, ref boxHalfExtent,
				ref sphereRelPos, out closestPoint, out normal);
		}

		public double GetSpherePenetration(Vector3d boxHalfExtent, Vector3d sphereRelPos,
			out Vector3d closestPoint, out Vector3d normal)
		{
			return btSphereBoxCollisionAlgorithm_getSpherePenetration(Native, ref boxHalfExtent,
				ref sphereRelPos, out closestPoint, out normal);
		}
	}
}
