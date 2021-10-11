using UnityEngine;

namespace Arkanoid
{
    public class PoolObject : MonoBehaviour
    {
        [SerializeField] private float delay = 0.5f;
        
        private void OnEnable()
        {
            Invoke("ReturnToPool", delay);
        }

        public void ReturnToPool()
        {
            gameObject.transform.localScale = Vector3.one;
            gameObject.SetActive(false);
        }
    }
}

