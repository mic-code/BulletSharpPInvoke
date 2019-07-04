using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BulletSharp.Math;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	[Flags]
	public enum RigidBodyFlags
	{
		None = 0,
		DisableWorldGravity = 1,
		EnableGyroscopicForceExplicit = 2,
		EnableGyroscopicForceImplicitWorld = 4,
		EnableGyroscopicForceImplicitBody = 8,
		EnableGyroscopicForce = EnableGyroscopicForceImplicitBody
	}

	public class RigidBody : CollisionObject
	{
		private MotionState _motionState;
		internal List<TypedConstraint> _constraintRefs;

		internal RigidBody(IntPtr native)
			: base(ConstructionInfo.Null)
		{
			InitializeSubObject(native, this);
		}

		public RigidBody(RigidBodyConstructionInfo constructionInfo)
			: base(ConstructionInfo.Null)
		{
			IntPtr native = btRigidBody_new(constructionInfo.Native);
			InitializeCollisionObject(native);

			_collisionShape = constructionInfo.CollisionShape;
			_motionState = constructionInfo.MotionState;
		}

		public void AddConstraintRef(TypedConstraint constraint)
		{
			if (_constraintRefs == null)
			{
				_constraintRefs = new List<TypedConstraint>();
			}
			_constraintRefs.Add(constraint);
			btRigidBody_addConstraintRef(Native, constraint.Native);
		}

		public void ApplyCentralForceRef(ref Vector3d force)
		{
			btRigidBody_applyCentralForce(Native, ref force);
		}

		public void ApplyCentralForce(Vector3d force)
		{
			btRigidBody_applyCentralForce(Native, ref force);
		}

		public void ApplyCentralImpulseRef(ref Vector3d impulse)
		{
			btRigidBody_applyCentralImpulse(Native, ref impulse);
		}

		public void ApplyCentralImpulse(Vector3d impulse)
		{
			btRigidBody_applyCentralImpulse(Native, ref impulse);
		}

		public void ApplyDamping(double timeStep)
		{
			btRigidBody_applyDamping(Native, timeStep);
		}

		public void ApplyForceRef(ref Vector3d force, ref Vector3d relPos)
		{
			btRigidBody_applyForce(Native, ref force, ref relPos);
		}

		public void ApplyForce(Vector3d force, Vector3d relPos)
		{
			btRigidBody_applyForce(Native, ref force, ref relPos);
		}

		public void ApplyGravity()
		{
			btRigidBody_applyGravity(Native);
		}

		public void ApplyImpulseRef(ref Vector3d impulse, ref Vector3d relPos)
		{
			btRigidBody_applyImpulse(Native, ref impulse, ref relPos);
		}

		public void ApplyImpulse(Vector3d impulse, Vector3d relPos)
		{
			btRigidBody_applyImpulse(Native, ref impulse, ref relPos);
		}

		public void ApplyTorqueRef(ref Vector3d torque)
		{
			btRigidBody_applyTorque(Native, ref torque);
		}

		public void ApplyTorque(Vector3d torque)
		{
			btRigidBody_applyTorque(Native, ref torque);
		}

		public void ApplyTorqueImpulseRef(ref Vector3d torque)
		{
			btRigidBody_applyTorqueImpulse(Native, ref torque);
		}

		public void ApplyTorqueImpulse(Vector3d torque)
		{
			btRigidBody_applyTorqueImpulse(Native, ref torque);
		}

		public void ClearForces()
		{
			btRigidBody_clearForces(Native);
		}

		public void ComputeAngularImpulseDenominator(ref Vector3d axis, out double result)
		{
			result = btRigidBody_computeAngularImpulseDenominator(Native, ref axis);
		}

		public double ComputeAngularImpulseDenominator(Vector3d axis)
		{
			return btRigidBody_computeAngularImpulseDenominator(Native, ref axis);
		}

		public Vector3d ComputeGyroscopicForceExplicit(double maxGyroscopicForce)
		{
			Vector3d value;
			btRigidBody_computeGyroscopicForceExplicit(Native, maxGyroscopicForce,
				out value);
			return value;
		}

		public Vector3d ComputeGyroscopicImpulseImplicitBody(double step)
		{
			Vector3d value;
			btRigidBody_computeGyroscopicImpulseImplicit_Body(Native, step, out value);
			return value;
		}

		public Vector3d ComputeGyroscopicImpulseImplicitWorld(double deltaTime)
		{
			Vector3d value;
			btRigidBody_computeGyroscopicImpulseImplicit_World(Native, deltaTime,
				out value);
			return value;
		}

		public double ComputeImpulseDenominator(Vector3d pos, Vector3d normal)
		{
			return btRigidBody_computeImpulseDenominator(Native, ref pos, ref normal);
		}

		public void GetAabb(out Vector3d aabbMin, out Vector3d aabbMax)
		{
			btRigidBody_getAabb(Native, out aabbMin, out aabbMax);
		}

		public TypedConstraint GetConstraintRef(int index)
		{
			System.Diagnostics.Debug.Assert(_constraintRefs != null);
			return _constraintRefs[index];
		}

		public void GetVelocityInLocalPoint(ref Vector3d relPos, out Vector3d value)
		{
			btRigidBody_getVelocityInLocalPoint(Native, ref relPos, out value);
		}

		public Vector3d GetVelocityInLocalPoint(Vector3d relPos)
		{
			Vector3d value;
			btRigidBody_getVelocityInLocalPoint(Native, ref relPos, out value);
			return value;
		}

		public void IntegrateVelocities(double step)
		{
			btRigidBody_integrateVelocities(Native, step);
		}

		public void PredictIntegratedTransform(double step, out Matrix predictedTransform)
		{
			btRigidBody_predictIntegratedTransform(Native, step, out predictedTransform);
		}

		public void ProceedToTransformRef(ref Matrix newTrans)
		{
			btRigidBody_proceedToTransform(Native, ref newTrans);
		}

		public void ProceedToTransform(Matrix newTrans)
		{
			btRigidBody_proceedToTransform(Native, ref newTrans);
		}

		public void RemoveConstraintRef(TypedConstraint constraint)
		{
			if (_constraintRefs != null)
			{
				_constraintRefs.Remove(constraint);
				btRigidBody_removeConstraintRef(Native, constraint.Native);
			}
		}

		public void SaveKinematicState(double step)
		{
			btRigidBody_saveKinematicState(Native, step);
		}

		public void SetDamping(double linDamping, double angDamping)
		{
			btRigidBody_setDamping(Native, linDamping, angDamping);
		}

		public void SetMassPropsRef(double mass, ref Vector3d inertia)
		{
			btRigidBody_setMassProps(Native, mass, ref inertia);
		}

		public void SetMassProps(double mass, Vector3d inertia)
		{
			btRigidBody_setMassProps(Native, mass, ref inertia);
		}

		public void SetNewBroadphaseProxy(BroadphaseProxy broadphaseProxy)
		{
			btRigidBody_setNewBroadphaseProxy(Native, broadphaseProxy.Native);
		}

		public void SetSleepingThresholds(double linear, double angular)
		{
			btRigidBody_setSleepingThresholds(Native, linear, angular);
		}

		public void TranslateRef(ref Vector3d v)
		{
			btRigidBody_translate(Native, ref v);
		}

		public void Translate(Vector3d v)
		{
			btRigidBody_translate(Native, ref v);
		}

		public static RigidBody Upcast(CollisionObject colObj)
		{
			return GetManaged(btRigidBody_upcast(colObj.Native)) as RigidBody;
		}

		public void UpdateDeactivation(double timeStep)
		{
			btRigidBody_updateDeactivation(Native, timeStep);
		}

		public void UpdateInertiaTensor()
		{
			btRigidBody_updateInertiaTensor(Native);
		}

		public bool WantsSleeping()
		{
			return btRigidBody_wantsSleeping(Native);
		}

		public double AngularDamping => btRigidBody_getAngularDamping(Native);

		public Vector3d AngularFactor
		{
			get
			{
				Vector3d value;
				btRigidBody_getAngularFactor(Native, out value);
				return value;
			}
			set => btRigidBody_setAngularFactor(Native, ref value);
		}

		public double AngularSleepingThreshold => btRigidBody_getAngularSleepingThreshold(Native);

		public Vector3d AngularVelocity
		{
			get
			{
				Vector3d value;
				btRigidBody_getAngularVelocity(Native, out value);
				return value;
			}
			set => btRigidBody_setAngularVelocity(Native, ref value);
		}

		public BroadphaseProxy BroadphaseProxy => BroadphaseProxy.GetManaged(btRigidBody_getBroadphaseProxy(Native));

		public Vector3d CenterOfMassPosition
		{
			get
			{
				Vector3d value;
				btRigidBody_getCenterOfMassPosition(Native, out value);
				return value;
			}
		}

		public Matrix CenterOfMassTransform
		{
			get
			{
				Matrix value;
				btRigidBody_getCenterOfMassTransform(Native, out value);
				return value;
			}
			set => btRigidBody_setCenterOfMassTransform(Native, ref value);
		}

		public int ContactSolverType
		{
			get => btRigidBody_getContactSolverType(Native);
			set => btRigidBody_setContactSolverType(Native, value);
		}

		public RigidBodyFlags Flags
		{
			get => btRigidBody_getFlags(Native);
			set => btRigidBody_setFlags(Native, value);
		}

		public int FrictionSolverType
		{
			get => btRigidBody_getFrictionSolverType(Native);
			set => btRigidBody_setFrictionSolverType(Native, value);
		}

		public Vector3d Gravity
		{
			get
			{
				Vector3d value;
				btRigidBody_getGravity(Native, out value);
				return value;
			}
			set => btRigidBody_setGravity(Native, ref value);
		}

		public Vector3d InvInertiaDiagLocal
		{
			get
			{
				Vector3d value;
				btRigidBody_getInvInertiaDiagLocal(Native, out value);
				return value;
			}
			set => btRigidBody_setInvInertiaDiagLocal(Native, ref value);
		}

		public Matrix InvInertiaTensorWorld
		{
			get
			{
				Matrix value;
				btRigidBody_getInvInertiaTensorWorld(Native, out value);
				return value;
			}
		}

		public double InvMass => btRigidBody_getInvMass(Native);

		public bool IsInWorld => btRigidBody_isInWorld(Native);

		public double LinearDamping => btRigidBody_getLinearDamping(Native);

		public Vector3d LinearFactor
		{
			get
			{
				Vector3d value;
				btRigidBody_getLinearFactor(Native, out value);
				return value;
			}
			set => btRigidBody_setLinearFactor(Native, ref value);
		}

		public double LinearSleepingThreshold => btRigidBody_getLinearSleepingThreshold(Native);

		public Vector3d LinearVelocity
		{
			get
			{
				Vector3d value;
				btRigidBody_getLinearVelocity(Native, out value);
				return value;
			}
			set => btRigidBody_setLinearVelocity(Native, ref value);
		}

		public Vector3d LocalInertia
		{
			get
			{
				Vector3d value;
				btRigidBody_getLocalInertia(Native, out value);
				return value;
			}
		}

		public MotionState MotionState
		{
			get => _motionState;
			set
			{
				btRigidBody_setMotionState(Native, (value != null) ? value.Native : IntPtr.Zero);
				_motionState = value;
			}
		}

		public int NumConstraintRefs => (_constraintRefs != null) ? _constraintRefs.Count : 0;

		public QuaternionD Orientation
		{
			get
			{
				QuaternionD value;
				btRigidBody_getOrientation(Native, out value);
				return value;
			}
		}

		public Vector3d TotalForce
		{
			get
			{
				Vector3d value;
				btRigidBody_getTotalForce(Native, out value);
				return value;
			}
		}

		public Vector3d TotalTorque
		{
			get
			{
				Vector3d value;
				btRigidBody_getTotalTorque(Native, out value);
				return value;
			}
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct RigidBodyFloatData
	{
		public CollisionObjectFloatData CollisionObjectData;
		public Matrix3x3FloatData InvInertiaTensorWorld;
		public Vector3FloatData LinearVelocity;
		public Vector3FloatData AngularVelocity;
		public Vector3FloatData AngularFactor;
		public Vector3FloatData LinearFactor;
		public Vector3FloatData Gravity;
		public Vector3FloatData GravityAcceleration;
		public Vector3FloatData InvInertiaLocal;
		public Vector3FloatData TotalForce;
		public Vector3FloatData TotalTorque;
		public float InverseMass;
		public float LinearDamping;
		public float AngularDamping;
		public float AdditionalDampingFactor;
		public float AdditionalLinearDampingThresholdSqr;
		public float AdditionalAngularDampingThresholdSqr;
		public float AdditionalAngularDampingFactor;
		public float LinearSleepingThreshold;
		public float AngularSleepingThreshold;
		public int AdditionalDamping;
		//public int Padding;

		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(RigidBodyFloatData), fieldName).ToInt32(); }
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct RigidBodyDoubleData
	{
		public CollisionObjectDoubleData CollisionObjectData;
		public Matrix3x3DoubleData InvInertiaTensorWorld;
		public Vector3DoubleData LinearVelocity;
		public Vector3DoubleData AngularVelocity;
		public Vector3DoubleData AngularFactor;
		public Vector3DoubleData LinearFactor;
		public Vector3DoubleData Gravity;
		public Vector3DoubleData GravityAcceleration;
		public Vector3DoubleData InvInertiaLocal;
		public Vector3DoubleData TotalForce;
		public Vector3DoubleData TotalTorque;
		public double InverseMass;
		public double LinearDamping;
		public double AngularDamping;
		public double AdditionalDampingFactor;
		public double AdditionalLinearDampingThresholdSqr;
		public double AdditionalAngularDampingThresholdSqr;
		public double AdditionalAngularDampingFactor;
		public double LinearSleepingThreshold;
		public double AngularSleepingThreshold;
		public int AdditionalDamping;
		//public int Padding;

		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(RigidBodyDoubleData), fieldName).ToInt32(); }
	}
}
