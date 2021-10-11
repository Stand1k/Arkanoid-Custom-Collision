using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    public class BrickService : Singleton<BrickService>
    {
        private List<GameObject> _brickGO;

        private void Start()
        {
            _brickGO = new List<GameObject>();
            
            for (int i = 0; i < transform.childCount; i++)
            {
                _brickGO.Add(transform.GetChild(i).gameObject);
            }
        }

        public bool RemoveAndCheckGameWon(GameObject gameObject)
        {
            if (_brickGO.Contains(gameObject)) _brickGO.Remove(gameObject);

            return _brickGO.Count <= 0;
        }
    }
}
