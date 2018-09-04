using System;
using System.Runtime.InteropServices;
using System.Security;
using BulletSharp.Math;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	[Flags]
	public enum SixDofFlags
	{
		None = 0,
		CfmNormal = 1,
		CfmStop = 2,
		ErpStop = 4
	}

	public class RotationalLimitMotor : IDisposable
	{
		internal IntPtr Native;
		bool _preventDelete;

		internal RotationalLimitMotor(IntPtr native, bool preventDelete)
		{
			Native = native;
			_preventDelete = preventDelete;
		}

		public RotationalLimitMotor()
		{
			Native = btRotationalLimitMotor_new();
		}

		public RotationalLimitMotor(RotationalLimitMotor limitMotor)
		{
			Native = btRotationalLimitMotor_new2(limitMotor.Native);
		}

		public bool NeedApplyTorques()
		{
			return btRotationalLimitMotor_needApplyTorques(Native);
		}

		public double SolveAngularLimitsRef(double timeStep, ref Vector3d axis, double jacDiagABInv,
			RigidBody body0, RigidBody body1)
		{
			return btRotationalLimitMotor_solveAngularLimits(Native, timeStep, ref axis,
				jacDiagABInv, body0.Native, body1.Native);
		}

		public double SolveAngularLimits(double timeStep, Vector3d axis, double jacDiagABInv,
			RigidBody body0, RigidBody body1)
		{
			return btRotationalLimitMotor_solveAngularLimits(Native, timeStep, ref axis,
				jacDiagABInv, body0.Native, body1.Native);
		}

		public int TestLimitValue(double testValue)
		{
			return btRotationalLimitMotor_testLimitValue(Native, testValue);
		}

		public double AccumulatedImpulse
		{
			get => btRotationalLimitMotor_getAccumulatedImpulse(Native);
			set => btRotationalLimitMotor_setAccumulatedImpulse(Native, value);
		}

		public double Bounce
		{
			get => btRotationalLimitMotor_getBounce(Native);
			set => btRotationalLimitMotor_setBounce(Native, value);
		}

		public int CurrentLimit
		{
			get => btRotationalLimitMotor_getCurrentLimit(Native);
			set => btRotationalLimitMotor_setCurrentLimit(Native, value);
		}

		public double CurrentLimitError
		{
			get => btRotationalLimitMotor_getCurrentLimitError(Native);
			set => btRotationalLimitMotor_setCurrentLimitError(Native, value);
		}

		public double CurrentPosition
		{
			get => btRotationalLimitMotor_getCurrentPosition(Native);
			set => btRotationalLimitMotor_setCurrentPosition(Native, value);
		}

		public double Damping
		{
			get => btRotationalLimitMotor_getDamping(Native);
			set => btRotationalLimitMotor_setDamping(Native, value);
		}

		public bool EnableMotor
		{
			get => btRotationalLimitMotor_getEnableMotor(Native);
			set => btRotationalLimitMotor_setEnableMotor(Native, value);
		}

		public double HiLimit
		{
			get => btRotationalLimitMotor_getHiLimit(Native);
			set => btRotationalLimitMotor_setHiLimit(Native, value);
		}

		public bool IsLimited => btRotationalLimitMotor_isLimited(Native);
		public double LimitSoftness
		{
			get => btRotationalLimitMotor_getLimitSoftness(Native);
			set => btRotationalLimitMotor_setLimitSoftness(Native, value);
		}

		public double LoLimit
		{
			get => btRotationalLimitMotor_getLoLimit(Native);
			set => btRotationalLimitMotor_setLoLimit(Native, value);
		}

		public double MaxLimitForce
		{
			get => btRotationalLimitMotor_getMaxLimitForce(Native);
			set => btRotationalLimitMotor_setMaxLimitForce(Native, value);
		}

		public double MaxMotorForce
		{
			get => btRotationalLimitMotor_getMaxMotorForce(Native);
			set => btRotationalLimitMotor_setMaxMotorForce(Native, value);
		}

		public double NormalCfm
		{
			get => btRotationalLimitMotor_getNormalCFM(Native);
			set => btRotationalLimitMotor_setNormalCFM(Native, value);
		}

		public double StopCfm
		{
			get => btRotationalLimitMotor_getStopCFM(Native);
			set => btRotationalLimitMotor_setStopCFM(Native, value);
		}

		public double StopErp
		{
			get => btRotationalLimitMotor_getStopERP(Native);
			set => btRotationalLimitMotor_setStopERP(Native, value);
		}

		public double TargetVelocity
		{
			get => btRotationalLimitMotor_getTargetVelocity(Native);
			set => btRotationalLimitMotor_setTargetVelocity(Native, value);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (Native != IntPtr.Zero)
			{
				if (!_preventDelete)
				{
					btRotationalLimitMotor_delete(Native);
				}
				Native = IntPtr.Zero;
			}
		}

		~RotationalLimitMotor()
		{
			Dispose(false);
		}
	}

	public class TranslationalLimitMotor : IDisposable
	{
		internal IntPtr Native;
		private bool _preventDelete;

		internal TranslationalLimitMotor(IntPtr native, bool preventDelete)
		{
			Native = native;
			_preventDelete = preventDelete;
		}

		public TranslationalLimitMotor()
		{
			Native = btTranslationalLimitMotor_new();
		}

		public TranslationalLimitMotor(TranslationalLimitMotor other)
		{
			Native = btTranslationalLimitMotor_new2(other.Native);
		}

		public bool IsLimited(int limitIndex)
		{
			return btTranslationalLimitMotor_isLimited(Native, limitIndex);
		}

		public bool NeedApplyForce(int limitIndex)
		{
			return btTranslationalLimitMotor_needApplyForce(Native, limitIndex);
		}

		public double SolveLinearAxisRef(double timeStep, double jacDiagABInv, RigidBody body1,
			ref Vector3d pointInA, RigidBody body2, ref Vector3d pointInB, int limitIndex, ref Vector3d axisNormalOnA,
			ref Vector3d anchorPos)
		{
			return btTranslationalLimitMotor_solveLinearAxis(Native, timeStep, jacDiagABInv,
				body1.Native, ref pointInA, body2.Native, ref pointInB, limitIndex,
				ref axisNormalOnA, ref anchorPos);
		}

		public double SolveLinearAxis(double timeStep, double jacDiagABInv, RigidBody body1,
			Vector3d pointInA, RigidBody body2, Vector3d pointInB, int limitIndex, Vector3d axisNormalOnA,
			Vector3d anchorPos)
		{
			return btTranslationalLimitMotor_solveLinearAxis(Native, timeStep, jacDiagABInv,
				body1.Native, ref pointInA, body2.Native, ref pointInB, limitIndex,
				ref axisNormalOnA, ref anchorPos);
		}

		public int TestLimitValue(int limitIndex, double testValue)
		{
			return btTranslationalLimitMotor_testLimitValue(Native, limitIndex,
				testValue);
		}

		public Vector3d AccumulatedImpulse
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor_getAccumulatedImpulse(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor_setAccumulatedImpulse(Native, ref value);
		}
		/*
		public IntArray CurrentLimit
		{
			get { return new IntArray(btTranslationalLimitMotor_getCurrentLimit(Native), 3); }
		}
		*/
		public Vector3d CurrentLimitError
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor_getCurrentLimitError(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor_setCurrentLimitError(Native, ref value);
		}

		public Vector3d CurrentLinearDiff
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor_getCurrentLinearDiff(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor_setCurrentLinearDiff(Native, ref value);
		}

		public double Damping
		{
			get => btTranslationalLimitMotor_getDamping(Native);
			set => btTranslationalLimitMotor_setDamping(Native, value);
		}
		/*
		public bool EnableMotor
		{
			get { return btTranslationalLimitMotor_getEnableMotor(_native); }
		}
		*/
		public double LimitSoftness
		{
			get => btTranslationalLimitMotor_getLimitSoftness(Native);
			set => btTranslationalLimitMotor_setLimitSoftness(Native, value);
		}

		public Vector3d LowerLimit
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor_getLowerLimit(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor_setLowerLimit(Native, ref value);
		}

		public Vector3d MaxMotorForce
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor_getMaxMotorForce(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor_setMaxMotorForce(Native, ref value);
		}

		public Vector3d NormalCfm
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor_getNormalCFM(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor_setNormalCFM(Native, ref value);
		}

		public double Restitution
		{
			get => btTranslationalLimitMotor_getRestitution(Native);
			set => btTranslationalLimitMotor_setRestitution(Native, value);
		}

		public Vector3d StopCfm
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor_getStopCFM(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor_setStopCFM(Native, ref value);
		}

		public Vector3d StopErp
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor_getStopERP(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor_setStopERP(Native, ref value);
		}

		public Vector3d TargetVelocity
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor_getTargetVelocity(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor_setTargetVelocity(Native, ref value);
		}

		public Vector3d UpperLimit
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor_getUpperLimit(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor_setUpperLimit(Native, ref value);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (Native != IntPtr.Zero)
			{
				if (!_preventDelete)
				{
					btTranslationalLimitMotor_delete(Native);
				}
				Native = IntPtr.Zero;
			}
		}

		~TranslationalLimitMotor()
		{
			Dispose(false);
		}
	}

	public class Generic6DofConstraint : TypedConstraint
	{
		private RotationalLimitMotor[] _angularLimits = new RotationalLimitMotor[3];
		private TranslationalLimitMotor _linearLimits;

		internal Generic6DofConstraint(IntPtr native)
			: base(native)
		{
		}

		public Generic6DofConstraint(RigidBody rigidBodyA, RigidBody rigidBodyB,
			Matrix frameInA, Matrix frameInB, bool useLinearReferenceFrameA)
			: base(btGeneric6DofConstraint_new(rigidBodyA.Native, rigidBodyB.Native,
				ref frameInA, ref frameInB, useLinearReferenceFrameA))
		{
			_rigidBodyA = rigidBodyA;
			_rigidBodyB = rigidBodyB;
		}

		public Generic6DofConstraint(RigidBody rigidBodyB, Matrix frameInB, bool useLinearReferenceFrameB)
			: base(btGeneric6DofConstraint_new2(rigidBodyB.Native, ref frameInB,
				useLinearReferenceFrameB))
		{
			_rigidBodyA = GetFixedBody();
			_rigidBodyB = rigidBodyB;
		}

		public void CalcAnchorPos()
		{
			btGeneric6DofConstraint_calcAnchorPos(Native);
		}

		public void CalculateTransformsRef(ref Matrix transA, ref Matrix transB)
		{
			btGeneric6DofConstraint_calculateTransforms(Native, ref transA, ref transB);
		}

		public void CalculateTransforms(Matrix transA, Matrix transB)
		{
			btGeneric6DofConstraint_calculateTransforms(Native, ref transA, ref transB);
		}

		public void CalculateTransforms()
		{
			btGeneric6DofConstraint_calculateTransforms2(Native);
		}

		public int GetLimitMotorInfo2(RotationalLimitMotor limitMotor, Matrix transA,
			Matrix transB, Vector3d linVelA, Vector3d linVelB, Vector3d angVelA, Vector3d angVelB,
			ConstraintInfo2 info, int row, ref Vector3d ax1, int rotational, int rotAllowed = 0)
		{
			return btGeneric6DofConstraint_get_limit_motor_info2(Native, limitMotor.Native,
				ref transA, ref transB, ref linVelA, ref linVelB, ref angVelA, ref angVelB,
				info._native, row, ref ax1, rotational, rotAllowed);
		}

		public double GetAngle(int axisIndex)
		{
			return btGeneric6DofConstraint_getAngle(Native, axisIndex);
		}

		public Vector3d GetAxis(int axisIndex)
		{
			Vector3d value;
			btGeneric6DofConstraint_getAxis(Native, axisIndex, out value);
			return value;
		}

		public void GetInfo1NonVirtual(ConstraintInfo1 info)
		{
			btGeneric6DofConstraint_getInfo1NonVirtual(Native, info._native);
		}

		public void GetInfo2NonVirtual(ConstraintInfo2 info, Matrix transA, Matrix transB,
			Vector3d linVelA, Vector3d linVelB, Vector3d angVelA, Vector3d angVelB)
		{
			btGeneric6DofConstraint_getInfo2NonVirtual(Native, info._native, ref transA,
				ref transB, ref linVelA, ref linVelB, ref angVelA, ref angVelB);
		}

		public double GetRelativePivotPosition(int axisIndex)
		{
			return btGeneric6DofConstraint_getRelativePivotPosition(Native, axisIndex);
		}

		public RotationalLimitMotor GetRotationalLimitMotor(int index)
		{
			if (_angularLimits[index] == null)
			{
				_angularLimits[index] = new RotationalLimitMotor(btGeneric6DofConstraint_getRotationalLimitMotor(Native, index), true);
			}
			return _angularLimits[index];
		}

		public bool IsLimited(int limitIndex)
		{
			return btGeneric6DofConstraint_isLimited(Native, limitIndex);
		}

		public void SetAxisRef(ref Vector3d axis1, ref Vector3d axis2)
		{
			btGeneric6DofConstraint_setAxis(Native, ref axis1, ref axis2);
		}

		public void SetAxis(Vector3d axis1, Vector3d axis2)
		{
			btGeneric6DofConstraint_setAxis(Native, ref axis1, ref axis2);
		}

		public void SetFramesRef(ref Matrix frameA, ref Matrix frameB)
		{
			btGeneric6DofConstraint_setFrames(Native, ref frameA, ref frameB);
		}

		public void SetFrames(Matrix frameA, Matrix frameB)
		{
			btGeneric6DofConstraint_setFrames(Native, ref frameA, ref frameB);
		}

		public void SetLimit(int axis, double lo, double hi)
		{
			btGeneric6DofConstraint_setLimit(Native, axis, lo, hi);
		}

		public bool TestAngularLimitMotor(int axisIndex)
		{
			return btGeneric6DofConstraint_testAngularLimitMotor(Native, axisIndex);
		}

		public void UpdateRhs(double timeStep)
		{
			btGeneric6DofConstraint_updateRHS(Native, timeStep);
		}

		public Vector3d AngularLowerLimit
		{
			get
			{
				Vector3d value;
				btGeneric6DofConstraint_getAngularLowerLimit(Native, out value);
				return value;
			}
			set => btGeneric6DofConstraint_setAngularLowerLimit(Native, ref value);
		}

		public Vector3d AngularUpperLimit
		{
			get
			{
				Vector3d value;
				btGeneric6DofConstraint_getAngularUpperLimit(Native, out value);
				return value;
			}
			set => btGeneric6DofConstraint_setAngularUpperLimit(Native, ref value);
		}

		public Matrix CalculatedTransformA
		{
			get
			{
				Matrix value;
				btGeneric6DofConstraint_getCalculatedTransformA(Native, out value);
				return value;
			}
		}

		public Matrix CalculatedTransformB
		{
			get
			{
				Matrix value;
				btGeneric6DofConstraint_getCalculatedTransformB(Native, out value);
				return value;
			}
		}

		public SixDofFlags Flags => btGeneric6DofConstraint_getFlags(Native);

		public Matrix FrameOffsetA
		{
			get
			{
				Matrix value;
				btGeneric6DofConstraint_getFrameOffsetA(Native, out value);
				return value;
			}
		}

		public Matrix FrameOffsetB
		{
			get
			{
				Matrix value;
				btGeneric6DofConstraint_getFrameOffsetB(Native, out value);
				return value;
			}
		}

		public Vector3d LinearLowerLimit
		{
			get
			{
				Vector3d value;
				btGeneric6DofConstraint_getLinearLowerLimit(Native, out value);
				return value;
			}
			set => btGeneric6DofConstraint_setLinearLowerLimit(Native, ref value);
		}

		public Vector3d LinearUpperLimit
		{
			get
			{
				Vector3d value;
				btGeneric6DofConstraint_getLinearUpperLimit(Native, out value);
				return value;
			}
			set => btGeneric6DofConstraint_setLinearUpperLimit(Native, ref value);
		}

		public TranslationalLimitMotor TranslationalLimitMotor
		{
			get
			{
				if (_linearLimits == null)
				{
					_linearLimits = new TranslationalLimitMotor(btGeneric6DofConstraint_getTranslationalLimitMotor(Native), true);
				}
				return _linearLimits;
			}
		}

		public bool UseFrameOffset
		{
			get => btGeneric6DofConstraint_getUseFrameOffset(Native);
			set => btGeneric6DofConstraint_setUseFrameOffset(Native, value);
		}

		public bool UseLinearReferenceFrameA
		{
			get => btGeneric6DofConstraint_getUseLinearReferenceFrameA(Native);
			set => btGeneric6DofConstraint_setUseLinearReferenceFrameA(Native, value);
		}

		public bool UseSolveConstraintObsolete
		{
			get => btGeneric6DofConstraint_getUseSolveConstraintObsolete(Native);
			set => btGeneric6DofConstraint_setUseSolveConstraintObsolete(Native, value);
		}
	}

    [StructLayout(LayoutKind.Sequential)]
    internal struct Generic6DofConstraintFloatData
	{
		public TypedConstraintFloatData TypedConstraintData;
		public TransformFloatData RigidBodyAFrame;
		public TransformFloatData RigidBodyBFrame;
		public Vector3FloatData LinearUpperLimit;
		public Vector3FloatData LinearLowerLimit;
		public Vector3FloatData AngularUpperLimit;
		public Vector3FloatData AngularLowerLimit;
		public int UseLinearReferenceFrameA;
		public int UseOffsetForConstraintFrame;

		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(Generic6DofConstraintFloatData), fieldName).ToInt32(); }
    }

	[StructLayout(LayoutKind.Sequential)]
	internal struct Generic6DofConstraintDoubleData
	{
		public TypedConstraintDoubleData TypedConstraintData;
		public TransformDoubleData RigidBodyAFrame;
		public TransformDoubleData RigidBodyBFrame;
		public Vector3DoubleData LinearUpperLimit;
		public Vector3DoubleData LinearLowerLimit;
		public Vector3DoubleData AngularUpperLimit;
		public Vector3DoubleData AngularLowerLimit;
		public int UseLinearReferenceFrameA;
		public int UseOffsetForConstraintFrame;

		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(Generic6DofConstraintDoubleData), fieldName).ToInt32(); }
	}
}
