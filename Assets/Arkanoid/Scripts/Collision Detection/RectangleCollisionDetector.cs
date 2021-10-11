using UnityEngine;

namespace Arkanoid
{
    [RequireComponent(typeof(RectangleCollider))]
    public class RectangleCollisionDetector : CollisionDetector<RectangleCollider>
    {
        private void Update()
        {
            baseCollider.UpdateCollider();

            foreach (var collisionObject in collisionObjects)
            {
                if (collisionObject == null) break;

                collisionObject.UpdateCollider();

                if (collisionObject.Intersects(baseCollider) && !collisionObject.Collide)
                {
                    collisionObject.Collide = true;
                    CollisionAction?.Invoke(collisionObject);
                }
                else if (collisionObject.Intersects(baseCollider) == false)
                {
                    collisionObject.Collide = false;
                }
            }
        }
    }
}