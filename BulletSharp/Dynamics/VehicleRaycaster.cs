using BulletSharp.Math;

namespace BulletSharp
{
    public class VehicleRaycasterResult
    {
        public double DistFraction { get; set; }
        public Vector3d HitNormalInWorld { get; set; }
        public Vector3d HitPointInWorld { get; set; }
    }
    
    public interface IVehicleRaycaster
	{
        object CastRay(ref Vector3d from, ref Vector3d to, VehicleRaycasterResult result);
	}
}
