using System;
using BulletSharp.Math;

namespace BulletSharp
{
	public struct WheelInfoConstructionInfo
	{
        public bool IsFrontWheel;
        public Vector3d ChassisConnectionCS;
        public double FrictionSlip;
        public double MaxSuspensionForce;
        public double MaxSuspensionTravelCm;
        public double SuspensionRestLength;
        public double SuspensionStiffness;
        public Vector3d WheelAxleCS;
        public Vector3d WheelDirectionCS;
        public double WheelRadius;
        public double WheelsDampingCompression;
        public double WheelsDampingRelaxation;
	}

    public struct RaycastInfo
    {
        public Vector3d ContactNormalWS;
        public Vector3d ContactPointWS;
        public Object GroundObject;
        public Vector3d HardPointWS;
        public bool IsInContact;
        public double SuspensionLength;
        public Vector3d WheelAxleWS;
        public Vector3d WheelDirectionWS;
    }

    public class WheelInfo
    {
        public WheelInfo(WheelInfoConstructionInfo ci)
        {
            SuspensionRestLength1 = ci.SuspensionRestLength;
            MaxSuspensionTravelCm = ci.MaxSuspensionTravelCm;

            WheelsRadius = ci.WheelRadius;
            SuspensionStiffness = ci.SuspensionStiffness;
            WheelsDampingCompression = ci.WheelsDampingCompression;
            WheelsDampingRelaxation = ci.WheelsDampingRelaxation;
            ChassisConnectionPointCS = ci.ChassisConnectionCS;
            WheelDirectionCS = ci.WheelDirectionCS;
            WheelAxleCS = ci.WheelAxleCS;
            FrictionSlip = ci.FrictionSlip;
            Steering = 0;
            EngineForce = 0;
            Rotation = 0;
            DeltaRotation = 0;
            Brake = 0;
            RollInfluence = 0.1f;
            IsFrontWheel = ci.IsFrontWheel;
            MaxSuspensionForce = ci.MaxSuspensionForce;

            //ClientInfo = IntPtr.Zero;
            //ClippedInvContactDotSuspension = 0;
            WorldTransform = Matrix.Identity;
            //WheelsSuspensionForce = 0;
            //SuspensionRelativeVelocity = 0;
            //SkidInfo = 0;
            RaycastInfo = new RaycastInfo();
        }

        public void UpdateWheel(RigidBody chassis, RaycastInfo raycastInfo)
        {
            if (raycastInfo.IsInContact)
            {
                double project = Vector3d.Dot(raycastInfo.ContactNormalWS, raycastInfo.WheelDirectionWS);
                Vector3d chassis_velocity_at_contactPoint;
                Vector3d relpos = raycastInfo.ContactPointWS - chassis.CenterOfMassPosition;
                chassis_velocity_at_contactPoint = chassis.GetVelocityInLocalPoint(relpos);
                double projVel = Vector3d.Dot(raycastInfo.ContactNormalWS, chassis_velocity_at_contactPoint);
                if (project >= -0.1f)
                {
                    SuspensionRelativeVelocity = 0;
                    ClippedInvContactDotSuspension = 1.0f / 0.1f;
                }
                else
                {
                    double inv = -1.0f / project;
                    SuspensionRelativeVelocity = projVel * inv;
                    ClippedInvContactDotSuspension = inv;
                }

            }

            else    // Not in contact : position wheel in a nice (rest length) position
            {
                RaycastInfo.SuspensionLength = SuspensionRestLength;
                SuspensionRelativeVelocity = 0;
                RaycastInfo.ContactNormalWS = -raycastInfo.WheelDirectionWS;
                ClippedInvContactDotSuspension = 1.0f;
            }
        }

        public double SuspensionRestLength
        {
            get { return SuspensionRestLength1; }
        }

        public bool IsFrontWheel;
        public double Brake;
        public Vector3d ChassisConnectionPointCS;
        public IntPtr ClientInfo;
        public double ClippedInvContactDotSuspension;
        public double DeltaRotation;
        public double EngineForce;
        public double FrictionSlip;
        public double MaxSuspensionForce;
        public double MaxSuspensionTravelCm;
        public RaycastInfo RaycastInfo;
        public double RollInfluence;
        public double Rotation;
        public double SkidInfo;
        public double Steering;
        public double SuspensionRelativeVelocity;
        public double SuspensionRestLength1;
        public double SuspensionStiffness;
        public Vector3d WheelAxleCS;
        public Vector3d WheelDirectionCS;
        public double WheelsDampingCompression;
        public double WheelsDampingRelaxation;
        public double WheelsRadius;
        public double WheelsSuspensionForce;
        public Matrix WorldTransform;
    }
}
