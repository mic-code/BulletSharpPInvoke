#include <btBulletDynamicsCommon.h>
#include "BulletCollision/CollisionShapes/btTriangleShape.h"
#include "BulletCollision/CollisionDispatch/btInternalEdgeUtility.h"
#include "customMethod.h"

static bool myCustomMaterialCombinerCallback(
	btManifoldPoint& cp,
	const btCollisionObjectWrapper* colObj0Wrap,
	int partId0,
	int index0,
	const btCollisionObjectWrapper* colObj1Wrap,
	int partId1,
	int index1
)
{
	// one-sided triangles
	//if (colObj1Wrap->getCollisionShape()->getShapeType() == TRIANGLE_SHAPE_PROXYTYPE)
	//{
	//	auto triShape = static_cast<const btTriangleShape*>(colObj1Wrap->getCollisionShape());
	//	const btVector3* v = triShape->m_vertices1;
	//	btVector3 faceNormalLs = btCross(v[1] - v[0], v[2] - v[0]);
	//	faceNormalLs.normalize();
	//	btVector3 faceNormalWs = colObj1Wrap->getWorldTransform().getBasis() * faceNormalLs;
	//	btScalar nDotF = btDot(faceNormalWs, cp.m_normalWorldOnB);
	//	if (nDotF <= 0.0f)
	//	{
	//		// flip the contact normal to be aligned with the face normal
	//		cp.m_normalWorldOnB += -2.0 * nDotF * faceNormalWs;
	//	}
	//}

	btAdjustInternalEdgeContacts(cp, colObj1Wrap, colObj0Wrap, partId1, index1);
	//this return value is currently ignored, but to be on the safe side: return false if you don't calculate friction
	return true;
}

bool ContactAdded(
	btManifoldPoint& cp,
	const btCollisionObjectWrapper* colObj0, int partId0, int index0,
	const btCollisionObjectWrapper* colObj1, int partId1, int index1)
{
	if (colObj0->getCollisionShape()->getShapeType() == TRIANGLE_SHAPE_PROXYTYPE)
	{
		btVector3 tempNorm;
		((btTriangleShape*)colObj0->getCollisionShape())->calcNormal(tempNorm);
		float dot = tempNorm.dot(cp.m_normalWorldOnB);
		cp.m_normalWorldOnB = dot > 0.0f ? tempNorm : -tempNorm;
	}
	else if (colObj1->getCollisionShape()->getShapeType() == TRIANGLE_SHAPE_PROXYTYPE)
	{
		btVector3 tempNorm;
		((btTriangleShape*)colObj1->getCollisionShape())->calcNormal(tempNorm);
		float dot = tempNorm.dot(cp.m_normalWorldOnB);
		cp.m_normalWorldOnB = dot > 0.0f ? tempNorm : -tempNorm;
	}
	return true;
}

void DisableGroundUndersideCollision() {
	gContactAddedCallback = ContactAdded;
}