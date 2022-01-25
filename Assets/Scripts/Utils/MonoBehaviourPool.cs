using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class MonoBehaviourPool<TPooledObject> : IObjectPool<TPooledObject> where TPooledObject : MonoBehaviour, IPoolable
    {
        protected Stack<TPooledObject> inactiveObjects;

        protected TPooledObject prefab;
        protected Transform parentTransform;

        public MonoBehaviourPool(int size, TPooledObject prefab, Transform parentTransform)
        {
            inactiveObjects = new Stack<TPooledObject>(size);

            this.prefab = prefab;
            this.parentTransform = parentTransform;

            for (int i = 0; i < size; i++) {
                var obj = InitializeObject();
                inactiveObjects.Push(obj);
            }
        }

        public virtual TPooledObject Get()
        {
            TPooledObject obj;

            if (inactiveObjects.Count > 0) {
                obj = inactiveObjects.Pop();
            } else {
                obj = InitializeObject();
            }

            return obj;
        }

        public virtual bool Release(TPooledObject obj)
        {
            if (inactiveObjects.Contains(obj)) {
                Debug.LogWarning($"{obj.name} object has already been released");
                return false;
            }

            obj.Release();
            obj.transform.SetParent(parentTransform, false);
            inactiveObjects.Push(obj);

            return true;
        }

        protected TPooledObject InitializeObject()
        {
            var obj = Object.Instantiate(prefab, parentTransform);
            obj.gameObject.SetActive(false);
            return obj;
        }
    }
}
