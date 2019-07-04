#include "BulletCollision/CollisionDispatch/btInternalEdgeUtility.h"
#include "BulletCollision\CollisionShapes\btBvhTriangleMeshShape.h"
#include "btInternalEdgeUtility_wrap.h"

void btInternalEdgeUtility_btGenerateInternalEdgeInfo(btBvhTriangleMeshShape* trimeshShape) {

	btTriangleInfoMap* triangleInfoMap = new btTriangleInfoMap();
	btGenerateInternalEdgeInfo(trimeshShape, triangleInfoMap);
}