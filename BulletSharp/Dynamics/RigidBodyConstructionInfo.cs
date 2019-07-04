using System;
using BulletSharp.Math;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	public class RigidBodyConstructionInfo : BulletDisposableObject
	{
		private CollisionShape _collisionShape;
		private MotionState _motionState;

		public RigidBodyConstructionInfo(double mass, MotionState motionState,
			CollisionShape collisionShape)
		{
			IntPtr native = btRigidBody_btRigidBodyConstructionInfo_new(mass, motionState != null ? motionState.Native : IntPtr.Zero,
				collisionShape != null ? collisionShape.Native : IntPtr.Zero);
			InitializeUserOwned(native);

			_collisionShape = collisionShape;
			_motionState = motionState;
		}

		public RigidBodyConstructionInfo(double mass, MotionState motionState,
			CollisionShape collisionShape, Vector3d localInertia)
		{
			IntPtr native = btRigidBody_btRigidBodyConstructionInfo_new2(mass, motionState != null ? motionState.Native : IntPtr.Zero,
				collisionShape != null ? collisionShape.Native : IntPtr.Zero, ref localInertia);
			InitializeUserOwned(native);

			_collisionShape = collisionShape;
			_motionState = motionState;
		}

		public double AdditionalAngularDampingFactor
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getAdditionalAngularDampingFactor(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setAdditionalAngularDampingFactor(Native, value);
		}

		public double AdditionalAngularDampingThresholdSqr
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getAdditionalAngularDampingThresholdSqr(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setAdditionalAngularDampingThresholdSqr(Native, value);
		}

		public bool AdditionalDamping
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getAdditionalDamping(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setAdditionalDamping(Native, value);
		}

		public double AdditionalDampingFactor
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getAdditionalDampingFactor(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setAdditionalDampingFactor(Native, value);
		}

		public double AdditionalLinearDampingThresholdSqr
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getAdditionalLinearDampingThresholdSqr(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setAdditionalLinearDampingThresholdSqr(Native, value);
		}

		public double AngularDamping
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getAngularDamping(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setAngularDamping(Native, value);
		}

		public double AngularSleepingThreshold
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getAngularSleepingThreshold(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setAngularSleepingThreshold(Native, value);
		}

		public CollisionShape CollisionShape
		{
			get => _collisionShape;
			set
			{
				btRigidBody_btRigidBodyConstructionInfo_setCollisionShape(Native, value != null ? value.Native : IntPtr.Zero);
				_collisionShape = value;
			}
		}

		public double Friction
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getFriction(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setFriction(Native, value);
		}

		public double LinearDamping
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getLinearDamping(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setLinearDamping(Native, value);
		}

		public double LinearSleepingThreshold
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getLinearSleepingThreshold(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setLinearSleepingThreshold(Native, value);
		}

		public Vector3d LocalInertia
		{
			get
			{
				Vector3d value;
				btRigidBody_btRigidBodyConstructionInfo_getLocalInertia(Native, out value);
				return value;
			}
			set => btRigidBody_btRigidBodyConstructionInfo_setLocalInertia(Native, ref value);
		}

		public double Mass
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getMass(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setMass(Native, value);
		}

		public MotionState MotionState
		{
			get => _motionState;
			set
			{
				btRigidBody_btRigidBodyConstructionInfo_setMotionState(Native, value != null ? value.Native : IntPtr.Zero);
				_motionState = value;
			}
		}

		public double Restitution
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getRestitution(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setRestitution(Native, value);
		}

		public double RollingFriction
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getRollingFriction(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setRollingFriction(Native, value);
		}

		public Matrix StartWorldTransform
		{
			get
			{
				Matrix value;
				btRigidBody_btRigidBodyConstructionInfo_getStartWorldTransform(Native, out value);
				return value;
			}
			set => btRigidBody_btRigidBodyConstructionInfo_setStartWorldTransform(Native, ref value);
		}

		protected override void Dispose(bool disposing)
		{
			btRigidBody_btRigidBodyConstructionInfo_delete(Native);
		}
	}
}
