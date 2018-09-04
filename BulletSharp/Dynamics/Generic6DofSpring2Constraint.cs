using System;
using System.Runtime.InteropServices;
using System.Security;
using BulletSharp.Math;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	public enum RotateOrder
	{
		XYZ,
		XZY,
		YXZ,
		YZX,
		ZXY,
		ZYX
	}

	public class RotationalLimitMotor2 : IDisposable
	{
		internal IntPtr _native;
		private bool _preventDelete;

		internal RotationalLimitMotor2(IntPtr native, bool preventDelete)
		{
			_native = native;
			_preventDelete = preventDelete;
		}

		public RotationalLimitMotor2()
		{
			_native = btRotationalLimitMotor2_new();
		}

		public RotationalLimitMotor2(RotationalLimitMotor2 limitMotor)
		{
			_native = btRotationalLimitMotor2_new2(limitMotor._native);
		}

		public void TestLimitValue(double testValue)
		{
			btRotationalLimitMotor2_testLimitValue(_native, testValue);
		}

		public double Bounce
		{
			get => btRotationalLimitMotor2_getBounce(_native);
			set => btRotationalLimitMotor2_setBounce(_native, value);
		}

		public int CurrentLimit
		{
			get => btRotationalLimitMotor2_getCurrentLimit(_native);
			set => btRotationalLimitMotor2_setCurrentLimit(_native, value);
		}

		public double CurrentLimitError
		{
			get => btRotationalLimitMotor2_getCurrentLimitError(_native);
			set => btRotationalLimitMotor2_setCurrentLimitError(_native, value);
		}

		public double CurrentLimitErrorHi
		{
			get => btRotationalLimitMotor2_getCurrentLimitErrorHi(_native);
			set => btRotationalLimitMotor2_setCurrentLimitErrorHi(_native, value);
		}

		public double CurrentPosition
		{
			get => btRotationalLimitMotor2_getCurrentPosition(_native);
			set => btRotationalLimitMotor2_setCurrentPosition(_native, value);
		}

		public bool EnableMotor
		{
			get => btRotationalLimitMotor2_getEnableMotor(_native);
			set => btRotationalLimitMotor2_setEnableMotor(_native, value);
		}

		public bool EnableSpring
		{
			get => btRotationalLimitMotor2_getEnableSpring(_native);
			set => btRotationalLimitMotor2_setEnableSpring(_native, value);
		}

		public double EquilibriumPoint
		{
			get => btRotationalLimitMotor2_getEquilibriumPoint(_native);
			set => btRotationalLimitMotor2_setEquilibriumPoint(_native, value);
		}

		public double HiLimit
		{
			get => btRotationalLimitMotor2_getHiLimit(_native);
			set => btRotationalLimitMotor2_setHiLimit(_native, value);
		}

		public bool IsLimited => btRotationalLimitMotor2_isLimited(_native);

		public double LoLimit
		{
			get => btRotationalLimitMotor2_getLoLimit(_native);
			set => btRotationalLimitMotor2_setLoLimit(_native, value);
		}

		public double MaxMotorForce
		{
			get => btRotationalLimitMotor2_getMaxMotorForce(_native);
			set => btRotationalLimitMotor2_setMaxMotorForce(_native, value);
		}

		public double MotorCfm
		{
			get => btRotationalLimitMotor2_getMotorCFM(_native);
			set => btRotationalLimitMotor2_setMotorCFM(_native, value);
		}

		public double MotorErp
		{
			get => btRotationalLimitMotor2_getMotorERP(_native);
			set => btRotationalLimitMotor2_setMotorERP(_native, value);
		}

		public bool ServoMotor
		{
			get => btRotationalLimitMotor2_getServoMotor(_native);
			set => btRotationalLimitMotor2_setServoMotor(_native, value);
		}

		public double ServoTarget
		{
			get => btRotationalLimitMotor2_getServoTarget(_native);
			set => btRotationalLimitMotor2_setServoTarget(_native, value);
		}

		public double SpringDamping
		{
			get => btRotationalLimitMotor2_getSpringDamping(_native);
			set => btRotationalLimitMotor2_setSpringDamping(_native, value);
		}

		public bool SpringDampingLimited
		{
			get => btRotationalLimitMotor2_getSpringDampingLimited(_native);
			set => btRotationalLimitMotor2_setSpringDampingLimited(_native, value);
		}

		public double SpringStiffness
		{
			get => btRotationalLimitMotor2_getSpringStiffness(_native);
			set => btRotationalLimitMotor2_setSpringStiffness(_native, value);
		}

		public bool SpringStiffnessLimited
		{
			get => btRotationalLimitMotor2_getSpringStiffnessLimited(_native);
			set => btRotationalLimitMotor2_setSpringStiffnessLimited(_native, value);
		}

		public double StopCfm
		{
			get => btRotationalLimitMotor2_getStopCFM(_native);
			set => btRotationalLimitMotor2_setStopCFM(_native, value);
		}

		public double StopErp
		{
			get => btRotationalLimitMotor2_getStopERP(_native);
			set => btRotationalLimitMotor2_setStopERP(_native, value);
		}

		public double TargetVelocity
		{
			get => btRotationalLimitMotor2_getTargetVelocity(_native);
			set => btRotationalLimitMotor2_setTargetVelocity(_native, value);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_native != IntPtr.Zero)
			{
				if (!_preventDelete)
				{
					btRotationalLimitMotor2_delete(_native);
				}
				_native = IntPtr.Zero;
			}
		}

		~RotationalLimitMotor2()
		{
			Dispose(false);
		}
	}

	public class TranslationalLimitMotor2 : IDisposable
	{
		internal IntPtr _native;
		bool _preventDelete;

		internal TranslationalLimitMotor2(IntPtr native, bool preventDelete)
		{
			_native = native;
			_preventDelete = preventDelete;
		}

		public TranslationalLimitMotor2()
		{
			_native = btTranslationalLimitMotor2_new();
		}

		public TranslationalLimitMotor2(TranslationalLimitMotor2 other)
		{
			_native = btTranslationalLimitMotor2_new2(other._native);
		}

		public bool IsLimited(int limitIndex)
		{
			return btTranslationalLimitMotor2_isLimited(_native, limitIndex);
		}

		public void TestLimitValue(int limitIndex, double testValue)
		{
			btTranslationalLimitMotor2_testLimitValue(_native, limitIndex, testValue);
		}

		public Vector3d Bounce
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor2_getBounce(_native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setBounce(_native, ref value);
		}
		/*
		public IntArray CurrentLimit
		{
			get { return new IntArray(btTranslationalLimitMotor2_getCurrentLimit(_native), 3); }
		}
		*/
		public Vector3d CurrentLimitError
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor2_getCurrentLimitError(_native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setCurrentLimitError(_native, ref value);
		}

		public Vector3d CurrentLimitErrorHi
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor2_getCurrentLimitErrorHi(_native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setCurrentLimitErrorHi(_native, ref value);
		}

		public Vector3d CurrentLinearDiff
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor2_getCurrentLinearDiff(_native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setCurrentLinearDiff(_native, ref value);
		}
		/*
		public BoolArray EnableMotor
		{
			get { return new BoolArray(btTranslationalLimitMotor2_getEnableMotor(_native), 3); }
		}

		public BoolArray EnableSpring
		{
			get { return new BoolArray(btTranslationalLimitMotor2_getEnableSpring(_native), 3); }
		}
		*/
		public Vector3d EquilibriumPoint
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor2_getEquilibriumPoint(_native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setEquilibriumPoint(_native, ref value);
		}

		public Vector3d LowerLimit
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor2_getLowerLimit(_native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setLowerLimit(_native, ref value);
		}

		public Vector3d MaxMotorForce
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor2_getMaxMotorForce(_native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setMaxMotorForce(_native, ref value);
		}

		public Vector3d MotorCFM
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor2_getMotorCFM(_native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setMotorCFM(_native, ref value);
		}

		public Vector3d MotorERP
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor2_getMotorERP(_native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setMotorERP(_native, ref value);
		}
		/*
		public BoolArray ServoMotor
		{
			get { return new BoolArray(btTranslationalLimitMotor2_getServoMotor(_native)); }
		}
		*/
		public Vector3d ServoTarget
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor2_getServoTarget(_native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setServoTarget(_native, ref value);
		}

		public Vector3d SpringDamping
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor2_getSpringDamping(_native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setSpringDamping(_native, ref value);
		}
		/*
		public BoolArray SpringDampingLimited
		{
			get { return btTranslationalLimitMotor2_getSpringDampingLimited(_native); }
		}
		*/
		public Vector3d SpringStiffness
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor2_getSpringStiffness(_native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setSpringStiffness(_native, ref value);
		}
		/*
		public BoolArray SpringStiffnessLimited
		{
			get { return btTranslationalLimitMotor2_getSpringStiffnessLimited(_native); }
		}
		*/
		public Vector3d StopCfm
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor2_getStopCFM(_native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setStopCFM(_native, ref value);
		}

		public Vector3d StopEep
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor2_getStopERP(_native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setStopERP(_native, ref value);
		}

		public Vector3d TargetVelocity
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor2_getTargetVelocity(_native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setTargetVelocity(_native, ref value);
		}

		public Vector3d UpperLimit
		{
			get
			{
				Vector3d value;
				btTranslationalLimitMotor2_getUpperLimit(_native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setUpperLimit(_native, ref value);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_native != IntPtr.Zero)
			{
				if (!_preventDelete)
				{
					btTranslationalLimitMotor2_delete(_native);
				}
				_native = IntPtr.Zero;
			}
		}

		~TranslationalLimitMotor2()
		{
			Dispose(false);
		}
	}

	public class Generic6DofSpring2Constraint : TypedConstraint
	{
		private RotationalLimitMotor2[] _angularLimits = new RotationalLimitMotor2[3];
		private TranslationalLimitMotor2 _linearLimits;

		internal Generic6DofSpring2Constraint(IntPtr native)
			: base(native)
		{
		}

		public Generic6DofSpring2Constraint(RigidBody rigidBodyA, RigidBody rigidBodyB,
			Matrix frameInA, Matrix frameInB, RotateOrder rotOrder = RotateOrder.XYZ)
			: base(btGeneric6DofSpring2Constraint_new(rigidBodyA.Native, rigidBodyB.Native,
				ref frameInA, ref frameInB, rotOrder))
		{
			_rigidBodyA = rigidBodyA;
			_rigidBodyB = rigidBodyB;
		}

		public Generic6DofSpring2Constraint(RigidBody rigidBodyB, Matrix frameInB,
			RotateOrder rotOrder = RotateOrder.XYZ)
			: base(btGeneric6DofSpring2Constraint_new2(rigidBodyB.Native, ref frameInB,
				rotOrder))
		{
			_rigidBodyA = GetFixedBody();
			_rigidBodyB = rigidBodyB;
		}

		public static double BtGetMatrixElem(Matrix mat, int index)
		{
			return btGeneric6DofSpring2Constraint_btGetMatrixElem(ref mat, index);
		}

		public void CalculateTransforms(Matrix transA, Matrix transB)
		{
			btGeneric6DofSpring2Constraint_calculateTransforms(Native, ref transA,
				ref transB);
		}

		public void CalculateTransforms()
		{
			btGeneric6DofSpring2Constraint_calculateTransforms2(Native);
		}

		public void EnableMotor(int index, bool onOff)
		{
			btGeneric6DofSpring2Constraint_enableMotor(Native, index, onOff);
		}

		public void EnableSpring(int index, bool onOff)
		{
			btGeneric6DofSpring2Constraint_enableSpring(Native, index, onOff);
		}

		public double GetAngle(int axisIndex)
		{
			return btGeneric6DofSpring2Constraint_getAngle(Native, axisIndex);
		}

		public Vector3d GetAxis(int axisIndex)
		{
			Vector3d value;
			btGeneric6DofSpring2Constraint_getAxis(Native, axisIndex, out value);
			return value;
		}

		public double GetRelativePivotPosition(int axisIndex)
		{
			return btGeneric6DofSpring2Constraint_getRelativePivotPosition(Native,
				axisIndex);
		}

		public RotationalLimitMotor2 GetRotationalLimitMotor(int index)
		{
			if (_angularLimits[index] == null)
			{
				_angularLimits[index] = new RotationalLimitMotor2(btGeneric6DofSpring2Constraint_getRotationalLimitMotor(Native, index), true);
			}
			return _angularLimits[index];
		}

		public bool IsLimited(int limitIndex)
		{
			return btGeneric6DofSpring2Constraint_isLimited(Native, limitIndex);
		}

		public static bool MatrixToEulerZXY(Matrix mat, ref Vector3d xyz)
		{
			return btGeneric6DofSpring2Constraint_matrixToEulerZXY(ref mat, ref xyz);
		}

		public static bool MatrixToEulerZYX(Matrix mat, ref Vector3d xyz)
		{
			return btGeneric6DofSpring2Constraint_matrixToEulerZYX(ref mat, ref xyz);
		}

		public static bool MatrixToEulerXZY(Matrix mat, ref Vector3d xyz)
		{
			return btGeneric6DofSpring2Constraint_matrixToEulerXZY(ref mat, ref xyz);
		}

		public static bool MatrixToEulerXYZ(Matrix mat, ref Vector3d xyz)
		{
			return btGeneric6DofSpring2Constraint_matrixToEulerXYZ(ref mat, ref xyz);
		}

		public static bool MatrixToEulerYZX(Matrix mat, ref Vector3d xyz)
		{
			return btGeneric6DofSpring2Constraint_matrixToEulerYZX(ref mat, ref xyz);
		}

		public static bool MatrixToEulerYXZ(Matrix mat, ref Vector3d xyz)
		{
			return btGeneric6DofSpring2Constraint_matrixToEulerYXZ(ref mat, ref xyz);
		}

		public void SetAxis(Vector3d axis1, Vector3d axis2)
		{
			btGeneric6DofSpring2Constraint_setAxis(Native, ref axis1, ref axis2);
		}

		public void SetBounce(int index, double bounce)
		{
			btGeneric6DofSpring2Constraint_setBounce(Native, index, bounce);
		}

		public void SetDamping(int index, double damping, bool limitIfNeeded = true)
		{
			btGeneric6DofSpring2Constraint_setDamping(Native, index, damping, limitIfNeeded);
		}

		public void SetEquilibriumPoint()
		{
			btGeneric6DofSpring2Constraint_setEquilibriumPoint(Native);
		}

		public void SetEquilibriumPoint(int index, double val)
		{
			btGeneric6DofSpring2Constraint_setEquilibriumPoint2(Native, index, val);
		}

		public void SetEquilibriumPoint(int index)
		{
			btGeneric6DofSpring2Constraint_setEquilibriumPoint3(Native, index);
		}

		public void SetFrames(Matrix frameA, Matrix frameB)
		{
			btGeneric6DofSpring2Constraint_setFrames(Native, ref frameA, ref frameB);
		}

		public void SetLimit(int axis, double lo, double hi)
		{
			btGeneric6DofSpring2Constraint_setLimit(Native, axis, lo, hi);
		}

		public void SetLimitReversed(int axis, double lo, double hi)
		{
			btGeneric6DofSpring2Constraint_setLimitReversed(Native, axis, lo, hi);
		}

		public void SetMaxMotorForce(int index, double force)
		{
			btGeneric6DofSpring2Constraint_setMaxMotorForce(Native, index, force);
		}

		public void SetServo(int index, bool onOff)
		{
			btGeneric6DofSpring2Constraint_setServo(Native, index, onOff);
		}

		public void SetServoTarget(int index, double target)
		{
			btGeneric6DofSpring2Constraint_setServoTarget(Native, index, target);
		}

		public void SetStiffness(int index, double stiffness, bool limitIfNeeded = true)
		{
			btGeneric6DofSpring2Constraint_setStiffness(Native, index, stiffness,
				limitIfNeeded);
		}

		public void SetTargetVelocity(int index, double velocity)
		{
			btGeneric6DofSpring2Constraint_setTargetVelocity(Native, index, velocity);
		}

		public Vector3d AngularLowerLimit
		{
			get
			{
				Vector3d value;
				btGeneric6DofSpring2Constraint_getAngularLowerLimit(Native, out value);
				return value;
			}
			set => btGeneric6DofSpring2Constraint_setAngularLowerLimit(Native, ref value);
		}

		public Vector3d AngularLowerLimitReversed
		{
			get
			{
				Vector3d value;
				btGeneric6DofSpring2Constraint_getAngularLowerLimitReversed(Native, out value);
				return value;
			}
			set => btGeneric6DofSpring2Constraint_setAngularLowerLimitReversed(Native, ref value);
		}

		public Vector3d AngularUpperLimit
		{
			get
			{
				Vector3d value;
				btGeneric6DofSpring2Constraint_getAngularUpperLimit(Native, out value);
				return value;
			}
			set => btGeneric6DofSpring2Constraint_setAngularUpperLimit(Native, ref value);
		}

		public Vector3d AngularUpperLimitReversed
		{
			get
			{
				Vector3d value;
				btGeneric6DofSpring2Constraint_getAngularUpperLimitReversed(Native, out value);
				return value;
			}
			set => btGeneric6DofSpring2Constraint_setAngularUpperLimitReversed(Native, ref value);
		}

		public Matrix CalculatedTransformA
		{
			get
			{
				Matrix value;
				btGeneric6DofSpring2Constraint_getCalculatedTransformA(Native, out value);
				return value;
			}
		}

		public Matrix CalculatedTransformB
		{
			get
			{
				Matrix value;
				btGeneric6DofSpring2Constraint_getCalculatedTransformB(Native, out value);
				return value;
			}
		}

		public Matrix FrameOffsetA
		{
			get
			{
				Matrix value;
				btGeneric6DofSpring2Constraint_getFrameOffsetA(Native, out value);
				return value;
			}
		}

		public Matrix FrameOffsetB
		{
			get
			{
				Matrix value;
				btGeneric6DofSpring2Constraint_getFrameOffsetB(Native, out value);
				return value;
			}
		}

		public Vector3d LinearLowerLimit
		{
			get
			{
				Vector3d value;
				btGeneric6DofSpring2Constraint_getLinearLowerLimit(Native, out value);
				return value;
			}
			set => btGeneric6DofSpring2Constraint_setLinearLowerLimit(Native, ref value);
		}

		public Vector3d LinearUpperLimit
		{
			get
			{
				Vector3d value;
				btGeneric6DofSpring2Constraint_getLinearUpperLimit(Native, out value);
				return value;
			}
			set => btGeneric6DofSpring2Constraint_setLinearUpperLimit(Native, ref value);
		}

		public RotateOrder RotationOrder
		{
			get => btGeneric6DofSpring2Constraint_getRotationOrder(Native);
			set => btGeneric6DofSpring2Constraint_setRotationOrder(Native, value);
		}

		public TranslationalLimitMotor2 TranslationalLimitMotor
		{
			get
			{
				if (_linearLimits == null)
				{
					_linearLimits = new TranslationalLimitMotor2(btGeneric6DofSpring2Constraint_getTranslationalLimitMotor(Native), true);
				}
				return _linearLimits;
			}
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct Generic6DofSpring2ConstraintFloatData
	{
		public TypedConstraintFloatData TypeConstraintData;
		public TransformFloatData RigidBodyAFrame;
		public TransformFloatData RigidBodyBFrame;
		public Vector3FloatData LinearUpperLimit;
		public Vector3FloatData LinearLowerLimit;
		public Vector3FloatData LinearBounce;
		public Vector3FloatData LinearStopErp;
		public Vector3FloatData LinearStopCfm;
		public Vector3FloatData LinearMotorErp;
		public Vector3FloatData LinearMotorCfm;
		public Vector3FloatData LinearTargetVelocity;
		public Vector3FloatData LinearMaxMotorForce;
		public Vector3FloatData LinearServoTarget;
		public Vector3FloatData LinearSpringStiffness;
		public Vector3FloatData LinearSpringDamping;
		public Vector3FloatData LinearEquilibriumPoint;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] LinearEnableMotor;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] LinearServoMotor;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] LinearEnableSpring;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] LinearSpringStiffnessLimited;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] LinearSpringDampingLimited;
		public int Padding;
		public Vector3FloatData AngularUpperLimit;
		public Vector3FloatData AngularLowerLimit;
		public Vector3FloatData AngularBounce;
		public Vector3FloatData AngularStopErp;
		public Vector3FloatData AngularStopCfm;
		public Vector3FloatData AngularMotorErp;
		public Vector3FloatData AngularMotorCfm;
		public Vector3FloatData AngularTargetVelocity;
		public Vector3FloatData AngularMaxMotorForce;
		public Vector3FloatData AngularServoTarget;
		public Vector3FloatData AngularSpringStiffness;
		public Vector3FloatData AngularSpringDamping;
		public Vector3FloatData AngularEquilibriumPoint;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] AngularEnableMotor;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] AngularServoMotor;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] AngularEnableSpring;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] AngularSpringStiffnessLimited;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] AngularSpringDampingLimited;
		public int RotateOrder;

		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(Generic6DofSpring2ConstraintFloatData), fieldName).ToInt32(); }
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct Generic6DofSpring2ConstraintDoubleData
	{
		public TypedConstraintDoubleData TypeConstraintData;
		public TransformDoubleData RigidBodyAFrame;
		public TransformDoubleData RigidBodyBFrame;
		public Vector3DoubleData LinearUpperLimit;
		public Vector3DoubleData LinearLowerLimit;
		public Vector3DoubleData LinearBounce;
		public Vector3DoubleData LinearStopErp;
		public Vector3DoubleData LinearStopCfm;
		public Vector3DoubleData LinearMotorErp;
		public Vector3DoubleData LinearMotorCfm;
		public Vector3DoubleData LinearTargetVelocity;
		public Vector3DoubleData LinearMaxMotorForce;
		public Vector3DoubleData LinearServoTarget;
		public Vector3DoubleData LinearSpringStiffness;
		public Vector3DoubleData LinearSpringDamping;
		public Vector3DoubleData LinearEquilibriumPoint;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] LinearEnableMotor;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] LinearServoMotor;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] LinearEnableSpring;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] LinearSpringStiffnessLimited;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] LinearSpringDampingLimited;
		public int Padding;
		public Vector3DoubleData AngularUpperLimit;
		public Vector3DoubleData AngularLowerLimit;
		public Vector3DoubleData AngularBounce;
		public Vector3DoubleData AngularStopErp;
		public Vector3DoubleData AngularStopCfm;
		public Vector3DoubleData AngularMotorErp;
		public Vector3DoubleData AngularMotorCfm;
		public Vector3DoubleData AngularTargetVelocity;
		public Vector3DoubleData AngularMaxMotorForce;
		public Vector3DoubleData AngularServoTarget;
		public Vector3DoubleData AngularSpringStiffness;
		public Vector3DoubleData AngularSpringDamping;
		public Vector3DoubleData AngularEquilibriumPoint;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] AngularEnableMotor;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] AngularServoMotor;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] AngularEnableSpring;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] AngularSpringStiffnessLimited;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] AngularSpringDampingLimited;
		public int RotateOrder;

		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(Generic6DofSpring2ConstraintDoubleData), fieldName).ToInt32(); }
	}
}
