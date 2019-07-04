using BulletSharp.Math;
using System;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	public class BoxBoxTransformCache : BulletDisposableObject
	{
		public BoxBoxTransformCache()
		{
			IntPtr native = BT_BOX_BOX_TRANSFORM_CACHE_new();
			InitializeUserOwned(native);
		}

		public void CalculateAbsoluteMatrix()
		{
			BT_BOX_BOX_TRANSFORM_CACHE_calc_absolute_matrix(Native);
		}

		public void CalculateFromFullInvertRef(ref Matrix transform0, ref Matrix transform1)
		{
			BT_BOX_BOX_TRANSFORM_CACHE_calc_from_full_invert(Native, ref transform0, ref transform1);
		}

		public void CalculateFromFullInvert(Matrix transform0, Matrix transform1)
		{
			BT_BOX_BOX_TRANSFORM_CACHE_calc_from_full_invert(Native, ref transform0, ref transform1);
		}

		public void CalculateFromFullHomogenicRef(ref Matrix transform0, ref Matrix transform1)
		{
			BT_BOX_BOX_TRANSFORM_CACHE_calc_from_homogenic(Native, ref transform0, ref transform1);
		}

		public void CalculateFromFullHomogenic(Matrix transform0, Matrix transform1)
		{
			BT_BOX_BOX_TRANSFORM_CACHE_calc_from_homogenic(Native, ref transform0, ref transform1);
		}

		public void TransformRef(ref Vector3d point, out Vector3d value)
		{
			BT_BOX_BOX_TRANSFORM_CACHE_transform(Native, ref point, out value);
		}

		public Vector3d Transform(Vector3d point)
		{
			Vector3d value;
			BT_BOX_BOX_TRANSFORM_CACHE_transform(Native, ref point, out value);
			return value;
		}

		public Matrix AbsoluteRotation
		{
			get
			{
				Matrix value;
				BT_BOX_BOX_TRANSFORM_CACHE_getAR(Native, out value);
				return value;
			}
			set { BT_BOX_BOX_TRANSFORM_CACHE_setAR(Native, ref value); }
		}

		public Matrix Rotation1To0
		{
			get
			{
				Matrix value;
				BT_BOX_BOX_TRANSFORM_CACHE_getR1to0(Native, out value);
				return value;
			}
			set { BT_BOX_BOX_TRANSFORM_CACHE_setR1to0(Native, ref value); }
		}

		public Vector3d Translation1To0
		{
			get
			{
				Vector3d value;
				BT_BOX_BOX_TRANSFORM_CACHE_getT1to0(Native, out value);
				return value;
			}
			set { BT_BOX_BOX_TRANSFORM_CACHE_setT1to0(Native, ref value); }
		}

		protected override void Dispose(bool disposing)
		{
			BT_BOX_BOX_TRANSFORM_CACHE_delete(Native);
		}
	}

	public sealed class Aabb : BulletDisposableObject
	{
		internal Aabb(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		public Aabb()
		{
			IntPtr native = btAABB_new();
			InitializeUserOwned(native);
		}

		public Aabb(Vector3d v1, Vector3d v2, Vector3d v3)
		{
			IntPtr native = btAABB_new2(ref v1, ref v2, ref v3);
			InitializeUserOwned(native);
		}

		public Aabb(Vector3d v1, Vector3d v2, Vector3d v3, double margin)
		{
			IntPtr native = btAABB_new3(ref v1, ref v2, ref v3, margin);
			InitializeUserOwned(native);
		}

		public Aabb(Aabb other)
		{
			IntPtr native = btAABB_new4(other.Native);
			InitializeUserOwned(native);
		}

		public Aabb(Aabb other, double margin)
		{
			IntPtr native = btAABB_new5(other.Native, margin);
			InitializeUserOwned(native);
		}

		public void ApplyTransformRef(ref Matrix transform)
		{
			btAABB_appy_transform(Native, ref transform);
		}

		public void ApplyTransform(Matrix transform)
		{
			btAABB_appy_transform(Native, ref transform);
		}

		public void ApplyTransformTransCache(BoxBoxTransformCache transformCache)
		{
			btAABB_appy_transform_trans_cache(Native, transformCache.Native);
		}

		public bool CollidePlaneRef(ref Vector4 plane)
		{
			return btAABB_collide_plane(Native, ref plane);
		}

		public bool CollidePlane(Vector4 plane)
		{
			return btAABB_collide_plane(Native, ref plane);
		}

		public bool CollideRayRef(ref Vector3d origin, ref Vector3d direction)
		{
			return btAABB_collide_ray(Native, ref origin, ref direction);
		}

		public bool CollideRay(Vector3d origin, Vector3d direction)
		{
			return btAABB_collide_ray(Native, ref origin, ref direction);
		}

		public bool CollideTriangleExactRef(ref Vector3d p1, ref Vector3d p2, ref Vector3d p3, ref Vector4 trianglePlane)
		{
			return btAABB_collide_triangle_exact(Native, ref p1, ref p2, ref p3,
				ref trianglePlane);
		}

		public bool CollideTriangleExact(Vector3d p1, Vector3d p2, Vector3d p3, Vector4 trianglePlane)
		{
			return btAABB_collide_triangle_exact(Native, ref p1, ref p2, ref p3,
				ref trianglePlane);
		}

		public void CopyWithMargin(Aabb other, double margin)
		{
			btAABB_copy_with_margin(Native, other.Native, margin);
		}

		public void FindIntersection(Aabb other, Aabb intersection)
		{
			btAABB_find_intersection(Native, other.Native, intersection.Native);
		}

		public void GetCenterExtend(out Vector3d center, out Vector3d extend)
		{
			btAABB_get_center_extend(Native, out center, out extend);
		}

		public bool HasCollision(Aabb other)
		{
			return btAABB_has_collision(Native, other.Native);
		}

		public void IncrementMargin(double margin)
		{
			btAABB_increment_margin(Native, margin);
		}

		public void Invalidate()
		{
			btAABB_invalidate(Native);
		}

		public void Merge(Aabb box)
		{
			btAABB_merge(Native, box.Native);
		}

		public bool OverlappingTransCache(Aabb box, BoxBoxTransformCache transformCache,
			bool fullTest)
		{
			return btAABB_overlapping_trans_cache(Native, box.Native, transformCache.Native,
				fullTest);
		}

		public bool OverlappingTransConservativeRef(Aabb box, ref Matrix transform1To0)
		{
			return btAABB_overlapping_trans_conservative(Native, box.Native, ref transform1To0);
		}

		public bool OverlappingTransConservative(Aabb box, Matrix transform1To0)
		{
			return btAABB_overlapping_trans_conservative(Native, box.Native, ref transform1To0);
		}

		public bool OverlappingTransConservative2(Aabb box, BoxBoxTransformCache transform1To0)
		{
			return btAABB_overlapping_trans_conservative2(Native, box.Native, transform1To0.Native);
		}

		public PlaneIntersectionType PlaneClassify(Vector4 plane)
		{
			return btAABB_plane_classify(Native, ref plane);
		}

		public void ProjectionIntervalRef(ref Vector3d direction, out double vmin, out double vmax)
		{
			btAABB_projection_interval(Native, ref direction, out vmin, out vmax);
		}

		public void ProjectionInterval(Vector3d direction, out double vmin, out double vmax)
		{
			btAABB_projection_interval(Native, ref direction, out vmin, out vmax);
		}

		public Vector3d Max
		{
			get
			{
				Vector3d value;
				btAABB_getMax(Native, out value);
				return value;
			}
			set { btAABB_setMax(Native, ref value); }
		}

		public Vector3d Min
		{
			get
			{
				Vector3d value;
				btAABB_getMin(Native, out value);
				return value;
			}
			set { btAABB_setMin(Native, ref value); }
		}

		protected override void Dispose(bool disposing)
		{
			if (IsUserOwned)
			{
				btAABB_delete(Native);
			}
		}
	}

	public enum PlaneIntersectionType
	{
		BackPlane,
		CollidePlane,
		FrontPlane
	}
}
