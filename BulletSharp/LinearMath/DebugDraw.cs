/*
 * C# / XNA  port of Bullet (c) 2011 Mark Neale <xexuxjy@hotmail.com>
 *
 * Bullet Continuous Collision Detection and Physics Library
 * Copyright (c) 2003-2008 Erwin Coumans  http://www.bulletphysics.com/
 *
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from
 * the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose, 
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *	claim that you wrote the original software. If you use this software
 *	in a product, an acknowledgment in the product documentation would be
 *	appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be
 *	misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
 */

using System;
using System.Security;
using System.Runtime.InteropServices;
using BulletSharp.Math;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	public abstract class DebugDraw : BulletDisposableObject
	{
		[UnmanagedFunctionPointer(BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawAabbUnmanagedDelegate([In] ref Vector3d from, [In] ref Vector3d to, [In] ref Vector3d color);
		[UnmanagedFunctionPointer(BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawArcUnmanagedDelegate([In] ref Vector3d center, [In] ref Vector3d normal, [In] ref Vector3d axis, double radiusA, double radiusB,
			double minAngle, double maxAngle, ref Vector3d color, bool drawSect, double stepDegrees);
		[UnmanagedFunctionPointer(BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawBoxUnmanagedDelegate([In] ref Vector3d bbMin, [In] ref Vector3d bbMax, [In] ref Matrix trans, [In] ref Vector3d color);
		[UnmanagedFunctionPointer(BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawCapsuleUnmanagedDelegate(double radius, double halfHeight, int upAxis, [In] ref Matrix transform, [In] ref Vector3d color);
		[UnmanagedFunctionPointer(BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawConeUnmanagedDelegate(double radius, double height, int upAxis, [In] ref Matrix transform, [In] ref Vector3d color);
		[UnmanagedFunctionPointer(BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawContactPointUnmanagedDelegate([In] ref Vector3d pointOnB, [In] ref Vector3d normalOnB, double distance, int lifeTime, [In] ref Vector3d color);
		[UnmanagedFunctionPointer(BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawCylinderUnmanagedDelegate(double radius, double halfHeight, int upAxis, [In] ref Matrix transform, [In] ref Vector3d color);
		[UnmanagedFunctionPointer(BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawLineUnmanagedDelegate([In] ref Vector3d from, [In] ref Vector3d to, [In] ref Vector3d color);
		[UnmanagedFunctionPointer(BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawPlaneUnmanagedDelegate([In] ref Vector3d planeNormal, double planeConst, [In] ref Matrix transform, [In] ref Vector3d color);
		[UnmanagedFunctionPointer(BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawSphereUnmanagedDelegate(double radius, [In] ref Matrix transform, [In] ref Vector3d color);
		[UnmanagedFunctionPointer(BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawSpherePatchUnmanagedDelegate([In] ref Vector3d center, [In] ref Vector3d up, [In] ref Vector3d axis, double radius,
			double minTh, double maxTh, double minPs, double maxPs, [In] ref Vector3d color, double stepDegrees);
		[UnmanagedFunctionPointer(BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawTransformUnmanagedDelegate([In] ref Matrix transform, double orthoLen);
		[UnmanagedFunctionPointer(BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void DrawTriangleUnmanagedDelegate([In] ref Vector3d v0, [In] ref Vector3d v1, [In] ref Vector3d v2, [In] ref Vector3d color, double alpha);
		[UnmanagedFunctionPointer(BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void SimpleCallback(int x);
		[UnmanagedFunctionPointer(BulletSharp.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate DebugDrawModes GetDebugModeUnmanagedDelegate();

		private readonly DrawAabbUnmanagedDelegate _drawAabb;
		private readonly DrawArcUnmanagedDelegate _drawArc;
		private readonly DrawBoxUnmanagedDelegate _drawBox;
		private readonly DrawCapsuleUnmanagedDelegate _drawCapsule;
		private readonly DrawConeUnmanagedDelegate _drawCone;
		private readonly DrawContactPointUnmanagedDelegate _drawContactPoint;
		private readonly DrawCylinderUnmanagedDelegate _drawCylinder;
		private readonly DrawLineUnmanagedDelegate _drawLine;
		private readonly DrawPlaneUnmanagedDelegate _drawPlane;
		private readonly DrawSphereUnmanagedDelegate _drawSphere;
		private readonly DrawSpherePatchUnmanagedDelegate _drawSpherePatch;
		private readonly DrawTransformUnmanagedDelegate _drawTransform;
		private readonly DrawTriangleUnmanagedDelegate _drawTriangle;
		private readonly GetDebugModeUnmanagedDelegate _getDebugMode;
		private readonly SimpleCallback _cb;

		internal static DebugDraw GetManaged(IntPtr debugDrawer)
		{
			if (debugDrawer == IntPtr.Zero)
			{
				return null;
			}

			IntPtr handle = btIDebugDrawWrapper_getGCHandle(debugDrawer);
			return GCHandle.FromIntPtr(handle).Target as DebugDraw;
		}
		
		private void SimpleCallbackUnmanaged(int x)
		{
			throw new NotImplementedException();
		}

		private DebugDrawModes GetDebugModeUnmanaged()
		{
			return DebugMode;
		}

		public DebugDraw()
		{
			_drawAabb = new DrawAabbUnmanagedDelegate(DrawAabb);
			_drawArc = new DrawArcUnmanagedDelegate(DrawArc);
			_drawBox = new DrawBoxUnmanagedDelegate(DrawBox);
			_drawCapsule = new DrawCapsuleUnmanagedDelegate(DrawCapsule);
			_drawCone = new DrawConeUnmanagedDelegate(DrawCone);
			_drawContactPoint = new DrawContactPointUnmanagedDelegate(DrawContactPoint);
			_drawCylinder = new DrawCylinderUnmanagedDelegate(DrawCylinder);
			_drawLine = new DrawLineUnmanagedDelegate(DrawLine);
			_drawPlane = new DrawPlaneUnmanagedDelegate(DrawPlane);
			_drawSphere = new DrawSphereUnmanagedDelegate(DrawSphere);
			_drawSpherePatch = new DrawSpherePatchUnmanagedDelegate(DrawSpherePatch);
			_drawTransform = new DrawTransformUnmanagedDelegate(DrawTransform);
			_drawTriangle = new DrawTriangleUnmanagedDelegate(DrawTriangle);
			_getDebugMode = new GetDebugModeUnmanagedDelegate(GetDebugModeUnmanaged);
			_cb = new SimpleCallback(SimpleCallbackUnmanaged);

			IntPtr native = btIDebugDrawWrapper_new(
				GCHandle.ToIntPtr(GCHandle.Alloc(this)),
				Marshal.GetFunctionPointerForDelegate(_drawAabb),
				Marshal.GetFunctionPointerForDelegate(_drawArc),
				Marshal.GetFunctionPointerForDelegate(_drawBox),
				Marshal.GetFunctionPointerForDelegate(_drawCapsule),
				Marshal.GetFunctionPointerForDelegate(_drawCone),
				Marshal.GetFunctionPointerForDelegate(_drawContactPoint),
				Marshal.GetFunctionPointerForDelegate(_drawCylinder),
				Marshal.GetFunctionPointerForDelegate(_drawLine),
				Marshal.GetFunctionPointerForDelegate(_drawPlane),
				Marshal.GetFunctionPointerForDelegate(_drawSphere),
				Marshal.GetFunctionPointerForDelegate(_drawSpherePatch),
				Marshal.GetFunctionPointerForDelegate(_drawTransform),
				Marshal.GetFunctionPointerForDelegate(_drawTriangle),
				Marshal.GetFunctionPointerForDelegate(_getDebugMode),
				Marshal.GetFunctionPointerForDelegate(_cb));
			InitializeUserOwned(native);
		}

		public abstract void DrawLine(ref Vector3d from, ref Vector3d to, ref Vector3d color);
		public abstract void Draw3DText(ref Vector3d location, String textString);
		public abstract void ReportErrorWarning(String warningString);
		public abstract DebugDrawModes DebugMode { get; set; }

		public void DrawLine(Vector3d from, Vector3d to, Vector3d color)
		{
			DrawLine(ref from, ref to, ref color);
		}

		public virtual void DrawLine(ref Vector3d from, ref Vector3d to, ref Vector3d fromColor, ref Vector3d toColor)
		{
			DrawLine(ref from, ref to, ref fromColor);
		}

		public virtual void DrawAabb(ref Vector3d from, ref Vector3d to, ref Vector3d color)
		{
			Vector3d a = from;
			a.X = to.X;
			DrawLine(ref from, ref a, ref color);

			Vector3d b = to;
			b.Y = from.Y;
			DrawLine(ref b, ref to, ref color);
			DrawLine(ref a, ref b, ref color);

			Vector3d c = from;
			c.Z = to.Z;
			DrawLine(ref from, ref c, ref color);
			DrawLine(ref b, ref c, ref color);

			b.Y = to.Y;
			b.Z = from.Z;
			DrawLine(ref b, ref to, ref color);
			DrawLine(ref a, ref b, ref color);

			a.Y = to.Y;
			a.X = from.X;
			DrawLine(ref from, ref a, ref color);
			DrawLine(ref a, ref b, ref color);

			b.X = from.X;
			b.Z = to.Z;
			DrawLine(ref c, ref b, ref color);
			DrawLine(ref a, ref b, ref color);
			DrawLine(ref b, ref to, ref color);
		}

		public virtual void DrawArc(ref Vector3d center, ref Vector3d normal, ref Vector3d axis, double radiusA, double radiusB,
			double minAngle, double maxAngle, ref Vector3d color, bool drawSect, double stepDegrees = 10.0f)
		{
			Vector3d xAxis = radiusA * axis;
			Vector3d yAxis = radiusB * Vector3d.Cross(normal, axis);
			double step = stepDegrees * MathUtil.SIMD_RADS_PER_DEG;
			int nSteps = (int)((maxAngle - minAngle) / step);
			if (nSteps == 0)
			{
				nSteps = 1;
			}
			Vector3d prev = center + xAxis * (float)System.Math.Cos(minAngle) + yAxis * (float)System.Math.Sin(minAngle);
			if (drawSect)
			{
				DrawLine(ref center, ref prev, ref color);
			}
			for (int i = 1; i <= nSteps; i++)
			{
				double angle = minAngle + (maxAngle - minAngle) * i / nSteps;
				Vector3d next = center + xAxis * (float)System.Math.Cos(angle) + yAxis * (float)System.Math.Sin(angle);
				DrawLine(ref prev, ref next, ref color);
				prev = next;
			}
			if (drawSect)
			{
				DrawLine(ref center, ref prev, ref color);
			}
		}

		public virtual void DrawBox(ref Vector3d bbMin, ref Vector3d bbMax, ref Vector3d color)
		{
			//Vector3 p1 = bbMin;
			Vector3d p2 = new Vector3d(bbMax.X, bbMin.Y, bbMin.Z);
			Vector3d p3 = new Vector3d(bbMax.X, bbMax.Y, bbMin.Z);
			Vector3d p4 = new Vector3d(bbMin.X, bbMax.Y, bbMin.Z);
			Vector3d p5 = new Vector3d(bbMin.X, bbMin.Y, bbMax.Z);
			Vector3d p6 = new Vector3d(bbMax.X, bbMin.Y, bbMax.Z);
			//Vector3 p7 = bbMax;
			Vector3d p8 = new Vector3d(bbMin.X, bbMax.Y, bbMax.Z);

			DrawLine(ref bbMin, ref p2, ref color);
			DrawLine(ref p2, ref p3, ref color);
			DrawLine(ref p3, ref p4, ref color);
			DrawLine(ref p4, ref bbMin, ref color);

			DrawLine(ref bbMin, ref p5, ref color);
			DrawLine(ref p2, ref p6, ref color);
			DrawLine(ref p3, ref bbMax, ref color);
			DrawLine(ref p4, ref p8, ref color);

			DrawLine(ref p5, ref p6, ref color);
			DrawLine(ref p6, ref bbMax, ref color);
			DrawLine(ref bbMax, ref p8, ref color);
			DrawLine(ref p8, ref p5, ref color);
		}

		public virtual void DrawBox(ref Vector3d bbMin, ref Vector3d bbMax, ref Matrix trans, ref Vector3d color)
		{
			Vector3d p1, p2, p3, p4, p5, p6, p7, p8;
			Vector3d point = bbMin;
			Vector3d.TransformCoordinate(ref point, ref trans, out p1);
			point.X = bbMax.X;
			Vector3d.TransformCoordinate(ref point, ref trans, out p2);
			point.Y = bbMax.Y;
			Vector3d.TransformCoordinate(ref point, ref trans, out p3);
			point.X = bbMin.X;
			Vector3d.TransformCoordinate(ref point, ref trans, out p4);
			point.Z = bbMax.Z;
			Vector3d.TransformCoordinate(ref point, ref trans, out p8);
			point.X = bbMax.X;
			Vector3d.TransformCoordinate(ref point, ref trans, out p7);
			point.Y = bbMin.Y;
			Vector3d.TransformCoordinate(ref point, ref trans, out p6);
			point.X = bbMin.X;
			Vector3d.TransformCoordinate(ref point, ref trans, out p5);

			DrawLine(ref p1, ref p2, ref color);
			DrawLine(ref p2, ref p3, ref color);
			DrawLine(ref p3, ref p4, ref color);
			DrawLine(ref p4, ref p1, ref color);

			DrawLine(ref p1, ref p5, ref color);
			DrawLine(ref p2, ref p6, ref color);
			DrawLine(ref p3, ref p7, ref color);
			DrawLine(ref p4, ref p8, ref color);

			DrawLine(ref p5, ref p6, ref color);
			DrawLine(ref p6, ref p7, ref color);
			DrawLine(ref p7, ref p8, ref color);
			DrawLine(ref p8, ref p5, ref color);
		}

		public virtual void DrawCapsule(double radius, double halfHeight, int upAxis, ref Matrix transform, ref Vector3d color)
		{
			Vector3d capStart = Vector3d.Zero;
			capStart[upAxis] = -halfHeight;

			Vector3d capEnd = Vector3d.Zero;
			capEnd[upAxis] = halfHeight;

			// Draw the ends
			Matrix childTransform = transform;
			childTransform.Origin = Vector3d.TransformCoordinate(capStart, transform);
			DrawSphere(radius, ref childTransform, ref color);

			childTransform.Origin = Vector3d.TransformCoordinate(capEnd, transform);
			DrawSphere(radius, ref childTransform, ref color);

			// Draw some additional lines
			Vector3d start = transform.Origin;
			Matrix basis = transform.Basis;

			capStart[(upAxis + 1) % 3] = radius;
			capEnd[(upAxis + 1) % 3] = radius;
			DrawLine(start + Vector3d.TransformCoordinate(capStart, basis), start + Vector3d.TransformCoordinate(capEnd, basis), color);

			capStart[(upAxis + 1) % 3] = -radius;
			capEnd[(upAxis + 1) % 3] = -radius;
			DrawLine(start + Vector3d.TransformCoordinate(capStart, basis), start + Vector3d.TransformCoordinate(capEnd, basis), color);

			capStart[(upAxis + 2) % 3] = radius;
			capEnd[(upAxis + 2) % 3] = radius;
			DrawLine(start + Vector3d.TransformCoordinate(capStart, basis), start + Vector3d.TransformCoordinate(capEnd, basis), color);

			capStart[(upAxis + 2) % 3] = -radius;
			capEnd[(upAxis + 2) % 3] = -radius;
			DrawLine(start + Vector3d.TransformCoordinate(capStart, basis), start + Vector3d.TransformCoordinate(capEnd, basis), color);
		}

		public virtual void DrawCone(double radius, double height, int upAxis, ref Matrix transform, ref Vector3d color)
		{
			Vector3d start = transform.Origin;

			Vector3d offsetHeight = Vector3d.Zero;
			offsetHeight[upAxis] = height * 0.5f;
			Vector3d offsetRadius = Vector3d.Zero;
			offsetRadius[(upAxis + 1) % 3] = radius;

			Vector3d offset2Radius = Vector3d.Zero;
			offsetRadius[(upAxis + 2) % 3] = radius;

			Matrix basis = transform.Basis;
			Vector3d from = start + Vector3d.TransformCoordinate(offsetHeight, basis);
			Vector3d to = start + Vector3d.TransformCoordinate(-offsetHeight, basis);
			DrawLine(from, to + offsetRadius, color);
			DrawLine(from, to - offsetRadius, color);
			DrawLine(from, to + offset2Radius, color);
			DrawLine(from, to - offset2Radius, color);
		}

		public virtual void DrawContactPoint(ref Vector3d pointOnB, ref Vector3d normalOnB, double distance, int lifeTime, ref Vector3d color)
		{
			Vector3d to = pointOnB + normalOnB * 1; // distance
			DrawLine(ref pointOnB, ref to, ref color);
		}

		public virtual void DrawCylinder(double radius, double halfHeight, int upAxis, ref Matrix transform, ref Vector3d color)
		{
			Vector3d start = transform.Origin;
			Matrix basis = transform.Basis;
			Vector3d offsetHeight = Vector3d.Zero;
			offsetHeight[upAxis] = halfHeight;
			Vector3d offsetRadius = Vector3d.Zero;
			offsetRadius[(upAxis + 1) % 3] = radius;
			DrawLine(start + Vector3d.TransformCoordinate(offsetHeight + offsetRadius, basis), start + Vector3d.TransformCoordinate(-offsetHeight + offsetRadius, basis), color);
			DrawLine(start + Vector3d.TransformCoordinate(offsetHeight - offsetRadius, basis), start + Vector3d.TransformCoordinate(-offsetHeight - offsetRadius, basis), color);
		}

		public virtual void DrawPlane(ref Vector3d planeNormal, double planeConst, ref Matrix transform, ref Vector3d color)
		{
			Vector3d planeOrigin = planeNormal * planeConst;
			Vector3d vec0, vec1;
			PlaneSpace1(ref planeNormal, out vec0, out vec1);
			const double vecLen = 100f;
			Vector3d pt0 = planeOrigin + vec0 * vecLen;
			Vector3d pt1 = planeOrigin - vec0 * vecLen;
			Vector3d pt2 = planeOrigin + vec1 * vecLen;
			Vector3d pt3 = planeOrigin - vec1 * vecLen;
			Vector3d.TransformCoordinate(ref pt0, ref transform, out pt0);
			Vector3d.TransformCoordinate(ref pt1, ref transform, out pt1);
			Vector3d.TransformCoordinate(ref pt2, ref transform, out pt2);
			Vector3d.TransformCoordinate(ref pt3, ref transform, out pt3);
			DrawLine(ref pt0, ref pt1, ref color);
			DrawLine(ref pt2, ref pt3, ref color);
		}

		public virtual void DrawSphere(double radius, ref Matrix transform, ref Vector3d color)
		{
			Vector3d start = transform.Origin;
			Matrix basis = transform.Basis;

			Vector3d xoffs = Vector3d.TransformCoordinate(new Vector3d(radius, 0, 0), basis);
			Vector3d yoffs = Vector3d.TransformCoordinate(new Vector3d(0, radius, 0), basis);
			Vector3d zoffs = Vector3d.TransformCoordinate(new Vector3d(0, 0, radius), basis);

			Vector3d xn = start - xoffs;
			Vector3d xp = start + xoffs;
			Vector3d yn = start - yoffs;
			Vector3d yp = start + yoffs;
			Vector3d zn = start - zoffs;
			Vector3d zp = start + zoffs;

			// XY
			DrawLine(ref xn, ref yp, ref color);
			DrawLine(ref yp, ref xp, ref color);
			DrawLine(ref xp, ref yn, ref color);
			DrawLine(ref yn, ref xn, ref color);

			// XZ
			DrawLine(ref xn, ref zp, ref color);
			DrawLine(ref zp, ref xp, ref color);
			DrawLine(ref xp, ref zn, ref color);
			DrawLine(ref zn, ref xn, ref color);

			// YZ
			DrawLine(ref yn, ref zp, ref color);
			DrawLine(ref zp, ref yp, ref color);
			DrawLine(ref yp, ref zn, ref color);
			DrawLine(ref zn, ref yn, ref color);
		}

		public virtual void DrawSphere(ref Vector3d p, double radius, ref Vector3d color)
		{
			Matrix tr = Matrix.Translation(p);
			DrawSphere(radius, ref tr, ref color);
		}

		public virtual void DrawSpherePatch(ref Vector3d center, ref Vector3d up, ref Vector3d axis, double radius,
			double minTh, double maxTh, double minPs, double maxPs, ref Vector3d color)
		{
			DrawSpherePatch(ref center, ref up, ref axis, radius, minTh, maxTh, minPs, maxPs, ref color, 10.0f);
		}

		public virtual void DrawSpherePatch(ref Vector3d center, ref Vector3d up, ref Vector3d axis, double radius,
			double minTh, double maxTh, double minPs, double maxPs, ref Vector3d color, double stepDegrees)
		{
			Vector3d[] vA;
			Vector3d[] vB;
			Vector3d[] pvA, pvB, pT;
			Vector3d npole = center + up * radius;
			Vector3d spole = center - up * radius;
			Vector3d arcStart = Vector3d.Zero;
			double step = stepDegrees * MathUtil.SIMD_RADS_PER_DEG;
			Vector3d kv = up;
			Vector3d iv = axis;

			Vector3d jv = Vector3d.Cross(kv, iv);
			bool drawN = false;
			bool drawS = false;
			if (minTh <= -MathUtil.SIMD_HALF_PI)
			{
				minTh = -MathUtil.SIMD_HALF_PI + step;
				drawN = true;
			}
			if (maxTh >= MathUtil.SIMD_HALF_PI)
			{
				maxTh = MathUtil.SIMD_HALF_PI - step;
				drawS = true;
			}
			if (minTh > maxTh)
			{
				minTh = -MathUtil.SIMD_HALF_PI + step;
				maxTh = MathUtil.SIMD_HALF_PI - step;
				drawN = drawS = true;
			}
			int n_hor = (int)((maxTh - minTh) / step) + 1;
			if (n_hor < 2) n_hor = 2;
			double step_h = (maxTh - minTh) / (n_hor - 1);
			bool isClosed;
			if (minPs > maxPs)
			{
				minPs = -MathUtil.SIMD_PI + step;
				maxPs = MathUtil.SIMD_PI;
				isClosed = true;
			}
			else if ((maxPs - minPs) >= MathUtil.SIMD_PI * 2f)
			{
				isClosed = true;
			}
			else
			{
				isClosed = false;
			}
			int n_vert = (int)((maxPs - minPs) / step) + 1;
			if (n_vert < 2) n_vert = 2;

			vA = new Vector3d[n_vert];
			vB = new Vector3d[n_vert];
			pvA = vA; pvB = vB;

			double step_v = (maxPs - minPs) / (double)(n_vert - 1);
			for (int i = 0; i < n_hor; i++)
			{
				double th = minTh + i * step_h;
				double sth = radius * (double)System.Math.Sin(th);
				double cth = radius * (double)System.Math.Cos(th);
				for (int j = 0; j < n_vert; j++)
				{
					double psi = minPs + (double)j * step_v;
					double sps = (double)System.Math.Sin(psi);
					double cps = (double)System.Math.Cos(psi);
					pvB[j] = center + cth * cps * iv + cth * sps * jv + sth * kv;
					if (i != 0)
					{
						DrawLine(ref pvA[j], ref pvB[j], ref color);
					}
					else if (drawS)
					{
						DrawLine(ref spole, ref pvB[j], ref color);
					}
					if (j != 0)
					{
						DrawLine(ref pvB[j - 1], ref pvB[j], ref color);
					}
					else
					{
						arcStart = pvB[j];
					}
					if ((i == (n_hor - 1)) && drawN)
					{
						DrawLine(ref npole, ref pvB[j], ref color);
					}
					if (isClosed)
					{
						if (j == (n_vert - 1))
						{
							DrawLine(ref arcStart, ref pvB[j], ref color);
						}
					}
					else
					{
						if (((i == 0) || (i == (n_hor - 1))) && ((j == 0) || (j == (n_vert - 1))))
						{
							DrawLine(ref center, ref pvB[j], ref color);
						}
					}
				}
				pT = pvA; pvA = pvB; pvB = pT;
			}
		}

		public virtual void DrawTriangle(ref Vector3d v0, ref Vector3d v1, ref Vector3d v2, ref Vector3d n0, ref Vector3d n1, ref Vector3d n2, ref Vector3d color, double alpha)
		{
			DrawTriangle(ref v0, ref v1, ref v2, ref color, alpha);
		}

		public virtual void DrawTriangle(ref Vector3d v0, ref Vector3d v1, ref Vector3d v2, ref Vector3d color, double alpha)
		{
			DrawLine(ref v0, ref v1, ref color);
			DrawLine(ref v1, ref v2, ref color);
			DrawLine(ref v2, ref v0, ref color);
		}

		public virtual void DrawTransform(ref Matrix transform, double orthoLen)
		{
			Vector3d start = transform.Origin;
			Matrix basis = transform.Basis;

			Vector3d ortho = new Vector3d(orthoLen, 0, 0);
			Vector3d colour = new Vector3d(0.7f, 0, 0);
			Vector3d temp;
			Vector3d.TransformCoordinate(ref ortho, ref basis, out temp);
			temp += start;
			DrawLine(ref start, ref temp, ref colour);

			ortho.X = 0;
			ortho.Y = orthoLen;
			colour.X = 0;
			colour.Y = 0.7f;
			Vector3d.TransformCoordinate(ref ortho, ref basis, out temp);
			temp += start;
			DrawLine(ref start, ref temp, ref colour);

			ortho.Y = 0;
			ortho.Z = orthoLen;
			colour.Y = 0;
			colour.Z = 0.7f;
			Vector3d.TransformCoordinate(ref ortho, ref basis, out temp);
			temp += start;
			DrawLine(ref start, ref temp, ref colour);
		}

		public static void PlaneSpace1(ref Vector3d n, out Vector3d p, out Vector3d q)
		{
			if (System.Math.Abs(n.Z) > MathUtil.SIMDSQRT12)
			{
				// choose p in y-z plane
				double a = n.Y * n.Y + n.Z * n.Z;
				double k = MathUtil.RecipSqrt(a);
				p = new Vector3d(0, -n.Z * k, n.Y * k);
				// set q = n x p
				q = new Vector3d(a * k, -n.X * p.Z, n.X * p.Y);
			}
			else
			{
				// choose p in x-y plane
				double a = n.X * n.X + n.Y * n.Y;
				double k = MathUtil.RecipSqrt(a);
				p = new Vector3d(-n.Y * k, n.X * k, 0);
				// set q = n x p
				q = new Vector3d(-n.Z * p.Y, n.Z * p.X, a * k);
			}
		}

		protected override void Dispose(bool disposing)
		{
			btIDebugDraw_delete(Native);
		}
	}
}
