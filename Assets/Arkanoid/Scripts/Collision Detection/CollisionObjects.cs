using System.Collections.Generic;

namespace Arkanoid
{
    public class CollisionObjects : Singleton<CollisionObjects>
    {
        public List<BaseCollider> baseColliders;

        private void Awake()
        {
            FindAllCollider<BaseCollider>();
        }

        private void FindAllCollider<T>() where T : BaseCollider
        {
            T[] _colliders = FindObjectsOfType<T>();

            foreach (var baseCollider in _colliders)
            {
                AddCollider(baseCollider);
            }
        }
        
        public void AddCollider(BaseCollider collider)
        {
            baseColliders.Add(collider);
        }
        
        public void RemoveCollider(BaseCollider collider)
        {
            baseColliders.Remove(collider);
        }
    }
}