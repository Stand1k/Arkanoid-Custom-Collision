using System;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    [RequireComponent(typeof(BaseCollider))]
    public class CollisionDetector<T>: MonoBehaviour, IColliderDestroy where T : BaseCollider
    {
        public Action<BaseCollider> CollisionAction;

        [HideInInspector] public T baseCollider;

        [HideInInspector] public List<BaseCollider> collisionObjects;

        private void Awake()
        {
            EventBus.Subscribe(this);
        }
        
        private void Start()
        {
            baseCollider = GetComponent<T>();
            CheckCollisionFilter();
        }

        public void CheckCollisionFilter()
        {
            foreach (var item in CollisionObjects.Instance.baseColliders)
            {
                if (item != baseCollider)
                {
                    collisionObjects.Add(item);
                }
            }
        }

        public void ColliderDestroy(BaseCollider collider)
        {
            if (collisionObjects.Contains(collider))
            {
                collisionObjects.Remove(collider);
            }
        }

        private void OnDestroy()
        {
            EventBus.Unsubscribe(this);
        }
    }
}