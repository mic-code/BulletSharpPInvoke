using BulletSharp.Math;

namespace BulletSharp
{
	internal class MyCallback : TriangleRaycastCallback
	{
		private readonly int _ignorePart;
		private readonly int _ignoreTriangleIndex;

		public MyCallback(ref Vector3d from, ref Vector3d to, int ignorePart, int ignoreTriangleIndex)
			: base(ref from, ref to)
		{
			_ignorePart = ignorePart;
			_ignoreTriangleIndex = ignoreTriangleIndex;
		}

		public override double ReportHit(ref Vector3d hitNormalLocal, double hitFraction, int partId, int triangleIndex)
		{
			if (partId != _ignorePart || triangleIndex != _ignoreTriangleIndex)
			{
				if (hitFraction < HitFraction)
					return hitFraction;
			}

			return HitFraction;
		}
	}

	internal class MyInternalTriangleIndexCallback : InternalTriangleIndexCallback
	{
		private readonly CompoundShape _collisionShape;
		private readonly double _depth;
		private readonly GImpactMeshShape _meshShape;
		//private readonly static Vector3 _redColor = new Vector3(1, 0, 0);

		public MyInternalTriangleIndexCallback(CompoundShape collisionShape, GImpactMeshShape meshShape, double depth)
		{
			_collisionShape = collisionShape;
			_depth = depth;
			_meshShape = meshShape;
		}

		public override void InternalProcessTriangleIndex(ref Vector3d vertex0, ref Vector3d vertex1, ref Vector3d vertex2, int partId, int triangleIndex)
		{
			Vector3d scale = _meshShape.LocalScaling;
			Vector3d v0 = vertex0 * scale;
			Vector3d v1 = vertex1 * scale;
			Vector3d v2 = vertex2 * scale;

			Vector3d centroid = (v0 + v1 + v2) / 3;
			Vector3d normal = (v1 - v0).Cross(v2 - v0);
			normal.Normalize();
			Vector3d rayFrom = centroid;
			Vector3d rayTo = centroid - normal * _depth;

			using (var cb = new MyCallback(ref rayFrom, ref rayTo, partId, triangleIndex))
			{
				_meshShape.ProcessAllTrianglesRayRef(cb, ref rayFrom, ref rayTo);
				if (cb.HitFraction < 1)
				{
					rayTo = Vector3d.Lerp(cb.From, cb.To, cb.HitFraction);
					//rayTo = cb.From;
					//Vector3 to = centroid + normal;
					//debugDraw.DrawLine(ref centroid, ref to, ref _redColor);
				}
			}

			var triangle = new BuSimplex1To4(v0, v1, v2, rayTo);
			_collisionShape.AddChildShape(Matrix.Identity, triangle);
		}
	}

	public static class CompoundFromGImpact
	{
		public static CompoundShape Create(GImpactMeshShape impactMesh, double depth)
		{
			var shape = new CompoundShape();
			using (var callback = new MyInternalTriangleIndexCallback(shape, impactMesh, depth))
			{
				Vector3d aabbMin, aabbMax;
				impactMesh.GetAabb(Matrix.Identity, out aabbMin, out aabbMax);
				impactMesh.MeshInterface.InternalProcessAllTriangles(callback, aabbMin, aabbMax);
			}
			return shape;
		}
	}
}
