using UnityEngine;

namespace Arkanoid
{
    public abstract class BaseCollider : MonoBehaviour
    {
        public bool Collide { get; set; }

        public float Angle { get; protected set; }
        
        public abstract void UpdateCollider();

        public abstract bool Intersects(CircleCollider circle);

        public abstract bool Intersects(RectangleCollider rectangle);
        
        private void OnDestroy()
        {
            EventBus.RaiseEvent<IColliderDestroy>(h => h.ColliderDestroy(this));
        }
    }
}