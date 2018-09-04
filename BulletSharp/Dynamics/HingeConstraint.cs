using System;
using System.Runtime.InteropServices;
using BulletSharp.Math;
using static BulletSharp.UnsafeNativeMethods;

namespace BulletSharp
{
	[Flags]
	public enum HingeFlags
	{
		None = 0,
		CfmStop = 1,
		ErpStop = 2,
		CfmNormal = 4,
		ErpNormal = 8
	}

	public class HingeConstraint : TypedConstraint
	{
		internal HingeConstraint(IntPtr native)
			: base(native)
		{
		}

		public HingeConstraint(RigidBody rigidBodyA, RigidBody rigidBodyB, Vector3d pivotInA,
			Vector3d pivotInB, Vector3d axisInA, Vector3d axisInB, bool useReferenceFrameA = false)
			: base(btHingeConstraint_new(rigidBodyA.Native, rigidBodyB.Native,
				ref pivotInA, ref pivotInB, ref axisInA, ref axisInB, useReferenceFrameA))
		{
			_rigidBodyA = rigidBodyA;
			_rigidBodyB = rigidBodyB;
		}

		public HingeConstraint(RigidBody rigidBodyA, Vector3d pivotInA, Vector3d axisInA,
			bool useReferenceFrameA = false)
			: base(btHingeConstraint_new2(rigidBodyA.Native, ref pivotInA, ref axisInA,
				useReferenceFrameA))
		{
			_rigidBodyA = rigidBodyA;
			_rigidBodyB = GetFixedBody();
		}

		public HingeConstraint(RigidBody rigidBodyA, RigidBody rigidBodyB, Matrix rigidBodyAFrame,
			Matrix rigidBodyBFrame, bool useReferenceFrameA = false)
			: base(btHingeConstraint_new3(rigidBodyA.Native, rigidBodyB.Native,
				ref rigidBodyAFrame, ref rigidBodyBFrame, useReferenceFrameA))
		{
			_rigidBodyA = rigidBodyA;
			_rigidBodyB = rigidBodyB;
		}

		public HingeConstraint(RigidBody rigidBodyA, Matrix rigidBodyAFrame, bool useReferenceFrameA = false)
			: base(btHingeConstraint_new4(rigidBodyA.Native, ref rigidBodyAFrame,
				useReferenceFrameA))
		{
			_rigidBodyA = rigidBodyA;
			_rigidBodyB = GetFixedBody();
		}

		public void EnableAngularMotor(bool enableMotor, double targetVelocity, double maxMotorImpulse)
		{
			btHingeConstraint_enableAngularMotor(Native, enableMotor, targetVelocity,
				maxMotorImpulse);
		}

		public double GetHingeAngleRef(ref Matrix transA, ref Matrix transB)
		{
			return btHingeConstraint_getHingeAngle(Native, ref transA, ref transB);
		}

		public double GetHingeAngle(Matrix transA, Matrix transB)
		{
			return btHingeConstraint_getHingeAngle(Native, ref transA, ref transB);
		}

		public void GetInfo1NonVirtual(ConstraintInfo1 info)
		{
			btHingeConstraint_getInfo1NonVirtual(Native, info._native);
		}

		public void GetInfo2Internal(ConstraintInfo2 info, Matrix transA, Matrix transB,
			Vector3d angVelA, Vector3d angVelB)
		{
			btHingeConstraint_getInfo2Internal(Native, info._native, ref transA,
				ref transB, ref angVelA, ref angVelB);
		}

		public void GetInfo2InternalUsingFrameOffset(ConstraintInfo2 info, Matrix transA,
			Matrix transB, Vector3d angVelA, Vector3d angVelB)
		{
			btHingeConstraint_getInfo2InternalUsingFrameOffset(Native, info._native,
				ref transA, ref transB, ref angVelA, ref angVelB);
		}

		public void GetInfo2NonVirtual(ConstraintInfo2 info, Matrix transA, Matrix transB,
			Vector3d angVelA, Vector3d angVelB)
		{
			btHingeConstraint_getInfo2NonVirtual(Native, info._native, ref transA,
				ref transB, ref angVelA, ref angVelB);
		}

		public void SetAxisRef(ref Vector3d axisInA)
		{
			btHingeConstraint_setAxis(Native, ref axisInA);
		}

		public void SetAxis(Vector3d axisInA)
		{
			btHingeConstraint_setAxis(Native, ref axisInA);
		}

		public void SetFramesRef(ref Matrix frameA, ref Matrix frameB)
		{
			btHingeConstraint_setFrames(Native, ref frameA, ref frameB);
		}

		public void SetFrames(Matrix frameA, Matrix frameB)
		{
			btHingeConstraint_setFrames(Native, ref frameA, ref frameB);
		}

		public void SetLimit(double low, double high)
		{
			btHingeConstraint_setLimit(Native, low, high);
		}

		public void SetLimit(double low, double high, double softness)
		{
			btHingeConstraint_setLimit2(Native, low, high, softness);
		}

		public void SetLimit(double low, double high, double softness, double biasFactor)
		{
			btHingeConstraint_setLimit3(Native, low, high, softness, biasFactor);
		}

		public void SetLimit(double low, double high, double softness, double biasFactor,
			double relaxationFactor)
		{
			btHingeConstraint_setLimit4(Native, low, high, softness, biasFactor,
				relaxationFactor);
		}

		public void SetMotorTarget(double targetAngle, double deltaTime)
		{
			btHingeConstraint_setMotorTarget(Native, targetAngle, deltaTime);
		}

		public void SetMotorTargetRef(ref Quaternion qAinB, double deltaTime)
		{
			btHingeConstraint_setMotorTarget2(Native, ref qAinB, deltaTime);
		}

		public void SetMotorTarget(Quaternion qAinB, double deltaTime)
		{
			btHingeConstraint_setMotorTarget2(Native, ref qAinB, deltaTime);
		}

		public void TestLimitRef(ref Matrix transA, ref Matrix transB)
		{
			btHingeConstraint_testLimit(Native, ref transA, ref transB);
		}

		public void TestLimit(Matrix transA, Matrix transB)
		{
			btHingeConstraint_testLimit(Native, ref transA, ref transB);
		}

		public void UpdateRhs(double timeStep)
		{
			btHingeConstraint_updateRHS(Native, timeStep);
		}

		public Matrix AFrame
		{
			get
			{
				Matrix value;
				btHingeConstraint_getAFrame(Native, out value);
				return value;
			}
		}

		public bool AngularOnly
		{
			get => btHingeConstraint_getAngularOnly(Native);
			set => btHingeConstraint_setAngularOnly(Native, value);
		}

		public Matrix BFrame
		{
			get
			{
				Matrix value;
				btHingeConstraint_getBFrame(Native, out value);
				return value;
			}
		}

		public bool EnableMotor
		{
			get => btHingeConstraint_getEnableAngularMotor(Native);
			set => btHingeConstraint_enableMotor(Native, value);
		}

		public HingeFlags Flags => btHingeConstraint_getFlags(Native);

		public Matrix FrameOffsetA
		{
			get
			{
				Matrix value;
				btHingeConstraint_getFrameOffsetA(Native, out value);
				return value;
			}
		}

		public Matrix FrameOffsetB
		{
			get
			{
				Matrix value;
				btHingeConstraint_getFrameOffsetB(Native, out value);
				return value;
			}
		}

		public bool HasLimit => btHingeConstraint_hasLimit(Native);

		public double HingeAngle => btHingeConstraint_getHingeAngle2(Native);

		public double LimitBiasFactor => btHingeConstraint_getLimitBiasFactor(Native);

		public double LimitRelaxationFactor => btHingeConstraint_getLimitRelaxationFactor(Native);

		public double LimitSign => btHingeConstraint_getLimitSign(Native);

		public double LimitSoftness => btHingeConstraint_getLimitSoftness(Native);

		public double LowerLimit => btHingeConstraint_getLowerLimit(Native);

		public double MaxMotorImpulse
		{
			get => btHingeConstraint_getMaxMotorImpulse(Native);
			set => btHingeConstraint_setMaxMotorImpulse(Native, value);
		}

		public double MotorTargetVelocity => btHingeConstraint_getMotorTargetVelocity(Native);

		public int SolveLimit => btHingeConstraint_getSolveLimit(Native);

		public double UpperLimit => btHingeConstraint_getUpperLimit(Native);

		public bool UseFrameOffset
		{
			get => btHingeConstraint_getUseFrameOffset(Native);
			set => btHingeConstraint_setUseFrameOffset(Native, value);
		}

		public bool UseReferenceFrameA
		{
			get => btHingeConstraint_getUseReferenceFrameA(Native);
			set => btHingeConstraint_setUseReferenceFrameA(Native, value);
		}
	}

	public class HingeAccumulatedAngleConstraint : HingeConstraint
	{
		public HingeAccumulatedAngleConstraint(RigidBody rigidBodyA, RigidBody rigidBodyB,
			Vector3d pivotInA, Vector3d pivotInB, Vector3d axisInA, Vector3d axisInB, bool useReferenceFrameA = false)
			: base(btHingeAccumulatedAngleConstraint_new(rigidBodyA.Native, rigidBodyB.Native,
				ref pivotInA, ref pivotInB, ref axisInA, ref axisInB, useReferenceFrameA))
		{
			_rigidBodyA = rigidBodyA;
			_rigidBodyB = rigidBodyB;
		}

		public HingeAccumulatedAngleConstraint(RigidBody rigidBodyA, Vector3d pivotInA,
			Vector3d axisInA, bool useReferenceFrameA = false)
			: base(btHingeAccumulatedAngleConstraint_new2(rigidBodyA.Native, ref pivotInA,
				ref axisInA, useReferenceFrameA))
		{
			_rigidBodyA = rigidBodyA;
			_rigidBodyB = GetFixedBody();
		}

		public HingeAccumulatedAngleConstraint(RigidBody rigidBodyA, RigidBody rigidBodyB,
			Matrix rigidBodyAFrame, Matrix rigidBodyBFrame, bool useReferenceFrameA = false)
			: base(btHingeAccumulatedAngleConstraint_new3(rigidBodyA.Native, rigidBodyB.Native,
				ref rigidBodyAFrame, ref rigidBodyBFrame, useReferenceFrameA))
		{
			_rigidBodyA = rigidBodyA;
			_rigidBodyB = rigidBodyB;
		}

		public HingeAccumulatedAngleConstraint(RigidBody rigidBodyA, Matrix rigidBodyAFrame,
			bool useReferenceFrameA = false)
			: base(btHingeAccumulatedAngleConstraint_new4(rigidBodyA.Native, ref rigidBodyAFrame,
				useReferenceFrameA))
		{
			_rigidBodyA = rigidBodyA;
			_rigidBodyB = GetFixedBody();
		}

		public double AccumulatedHingeAngle
		{
			get => btHingeAccumulatedAngleConstraint_getAccumulatedHingeAngle(Native);
			set => btHingeAccumulatedAngleConstraint_setAccumulatedHingeAngle(Native, value);
		}
	}

    [StructLayout(LayoutKind.Sequential)]
    internal struct HingeConstraintFloatData
    {
        public TypedConstraintFloatData TypedConstraintData;
		public TransformFloatData RigidBodyAFrame;
		public TransformFloatData RigidBodyBFrame;
		public int UseReferenceFrameA;
		public int AngularOnly;
		public int EnableAngularMotor;
		public float MotorTargetVelocity;
		public float MaxMotorImpulse;
		public float LowerLimit;
		public float UpperLimit;
		public float LimitSoftness;
		public float BiasFactor;
		public float RelaxationFactor;

		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(HingeConstraintFloatData), fieldName).ToInt32(); }
    }

	[StructLayout(LayoutKind.Sequential)]
	internal struct HingeConstraintDoubleData
	{
		public TypedConstraintDoubleData TypedConstraintData;
		public TransformDoubleData RigidBodyAFrame;
		public TransformDoubleData RigidBodyBFrame;
		public int UseReferenceFrameA;
		public int AngularOnly;
		public int EnableAngularMotor;
		public double MotorTargetVelocity;
		public double MaxMotorImpulse;
		public double LowerLimit;
		public double UpperLimit;
		public double LimitSoftness;
		public double BiasFactor;
		public double RelaxationFactor;

		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(HingeConstraintDoubleData), fieldName).ToInt32(); }
	}
}
