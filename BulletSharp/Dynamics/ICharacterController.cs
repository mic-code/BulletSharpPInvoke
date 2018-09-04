using BulletSharp.Math;

namespace BulletSharp
{
	public interface ICharacterController : IAction
	{
        bool CanJump { get; }
        bool OnGround { get; }

        void Jump();
        void Jump(Vector3d dir);
        void PlayerStep(CollisionWorld collisionWorld, double deltaTime);
        void PreStep(CollisionWorld collisionWorld);
        void Reset(CollisionWorld collisionWorld);
        void SetUpInterpolate(bool value);
        void SetVelocityForTimeInterval(ref Vector3d velocity, double timeInterval);
        void SetWalkDirection(ref Vector3d walkDirection);
        void Warp(ref Vector3d origin);
	}
}
