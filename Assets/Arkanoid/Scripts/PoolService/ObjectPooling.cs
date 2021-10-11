using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    public class ObjectPooling
    {
        private List<PoolObject> _objects;
        private Transform _objectsParent;

        public void Initialize(int count, PoolObject sample, Transform objectsParent)
        {
            _objects = new List<PoolObject>();
            _objectsParent = objectsParent;
            for (int i = 0; i < count; i++)
            {
                AddObject(sample, objectsParent);
            }
        }

        public PoolObject GetObject()
        {
            for (int i = 0; i < _objects.Count; i++)
            {
                if (_objects[i].gameObject.activeInHierarchy == false)
                {
                    return _objects[i];
                }
            }

            AddObject(_objects[0], _objectsParent);
            return _objects[_objects.Count - 1];
        }

        void AddObject(PoolObject sample, Transform objectsParent)
        {
            if (Object.Instantiate((Object) sample.gameObject) is GameObject { } temp)
            {
                temp.name = sample.name;
                temp.transform.SetParent(objectsParent);
                _objects.Add(temp.GetComponent<PoolObject>());
                if (temp.GetComponent<Animator>())
                    temp.GetComponent<Animator>().StartPlayback();
                temp.SetActive(false);
            }
        }
    }
}