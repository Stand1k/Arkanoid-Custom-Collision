using UnityEngine;

namespace Arkanoid
{
    public class PoolSetup : MonoBehaviour
    {
        [SerializeField] private PoolService.PoolPart[] pools;

        void OnValidate()
        {
            for (int i = 0; i < pools.Length; i++)
            {
                pools[i].name = pools[i].prefab.name;
            }
        }

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            PoolService.Initialize(pools);
        }
    }
}