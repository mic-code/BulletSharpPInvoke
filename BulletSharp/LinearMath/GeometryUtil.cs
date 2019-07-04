using BulletSharp.Math;
using System.Collections.Generic;
using System.Linq;

namespace BulletSharp
{
	public static class GeometryUtil
	{
		public static bool AreVerticesBehindPlane(Vector3d planeNormal, double planeConstant, IEnumerable<Vector3d> vertices,
			double margin)
		{
			return vertices.All(v => planeNormal.Dot(v) + planeConstant <= margin);
		}

		public static List<Vector4> GetPlaneEquationsFromVertices(ICollection<Vector3d> vertices)
		{
			int numVertices = vertices.Count;
			Vector3d[] vertexArray = vertices.ToArray();
			var planeEquations = new List<Vector4>();

			for (int i = 0; i < numVertices; i++)
			{
				for (int j = i + 1; j < numVertices; j++)
				{
					for (int k = j + 1; k < numVertices; k++)
					{
						Vector3d edge0 = vertexArray[j] - vertexArray[i];
						Vector3d edge1 = vertexArray[k] - vertexArray[i];

						Vector3d normal = edge0.Cross(edge1);
						if (normal.LengthSquared > 0.0001)
						{
							normal.Normalize();
							if (!Vector4EnumerableContainsVector3(planeEquations, normal))
							{
								double constant = -normal.Dot(vertexArray[i]);
								if (AreVerticesBehindPlane(normal, constant, vertexArray, 0.01f))
								{
									planeEquations.Add(new Vector4(normal, constant));
								}
							}

							normal = -normal;
							if (!Vector4EnumerableContainsVector3(planeEquations, normal))
							{
								double constant = -normal.Dot(vertexArray[i]);
								if (AreVerticesBehindPlane(normal, constant, vertexArray, 0.01f))
								{
									planeEquations.Add(new Vector4(normal, constant));
								}
							}
						}
					}
				}
			}

			return planeEquations;
		}

		private static bool Vector4EnumerableContainsVector3(IEnumerable<Vector4> vertices, Vector3d vertex)
		{
			return vertices.Any(v => {
				var v3 = new Vector3d(v.X, v.Y, v.Z);
				return v3.Dot(vertex) > 0.999;
			});
		}

		public static List<Vector3d> GetVerticesFromPlaneEquations(ICollection<Vector4> planeEquations)
		{
			int numPlanes = planeEquations.Count;
			Vector3d[] planeNormals = new Vector3d[numPlanes];
			double[] planeConstants = new double[numPlanes];
			int i = 0;
			foreach (Vector4 plane in planeEquations)
			{
				planeNormals[i] = new Vector3d(plane.X, plane.Y, plane.Z);
				planeConstants[i] = plane.W;
				i++;
			}

			var vertices = new List<Vector3d>();

			for (i = 0; i < numPlanes; i++)
			{
				for (int j = i + 1; j < numPlanes; j++)
				{
					for (int k = j + 1; k < numPlanes; k++)
					{
						Vector3d n2n3 = planeNormals[j].Cross(planeNormals[k]);
						Vector3d n3n1 = planeNormals[k].Cross(planeNormals[i]);
						Vector3d n1n2 = planeNormals[i].Cross(planeNormals[j]);

						if ((n2n3.LengthSquared > 0.0001f) &&
							 (n3n1.LengthSquared > 0.0001f) &&
							 (n1n2.LengthSquared > 0.0001f))
						{
							//point P out of 3 plane equations:

							//	  d1 ( N2 * N3 ) + d2 ( N3 * N1 ) + d3 ( N1 * N2 )  
							//P = ------------------------------------------------
							//	N1 . ( N2 * N3 )  

							double quotient = planeNormals[i].Dot(n2n3);
							if (System.Math.Abs(quotient) > 0.000001)
							{
								quotient = -1.0f / quotient;
								n2n3 *= planeConstants[i];
								n3n1 *= planeConstants[j];
								n1n2 *= planeConstants[k];
								Vector3d potentialPoint = quotient * (n2n3 + n3n1 + n1n2);

								//check if inside, and replace supportingVertexOut if needed
								if (IsPointInsidePlanes(planeEquations, potentialPoint, 0.01f))
								{
									vertices.Add(potentialPoint);
								}
							}
						}
					}
				}
			}

			return vertices;
		}

		public static bool IsPointInsidePlanes(IEnumerable<Vector4> planeEquations,
			Vector3d point, double margin)
		{
			return planeEquations.All(p => new Vector3d(p.X, p.Y, p.Z).Dot(point) + p.W <= margin);
		}
	}
}
