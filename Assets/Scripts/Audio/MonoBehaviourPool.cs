using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class MonoBehaviourPool<TPooledObject> : IObjectPool<TPooledObject> where TPooledObject : MonoBehaviour
    {
        private Stack<TPooledObject> inactiveObjects;

        private TPooledObject prefab;
        private Transform parentTransform;

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

        public TPooledObject Get()
        {
            TPooledObject obj;

            if (inactiveObjects.Count > 0) {
                obj = inactiveObjects.Pop();
            } else {
                obj = InitializeObject();
            }

            return obj;
        }

        public void Release(TPooledObject obj)
        {
            if (!inactiveObjects.Contains(obj)) {
                obj.gameObject.SetActive(false);
                obj.transform.SetParent(parentTransform);
                inactiveObjects.Push(obj);
            } else {
                Debug.LogWarning($"{obj.name} object has already been released");
            }

        }

        private TPooledObject InitializeObject()
        {
            var obj = Object.Instantiate(prefab, parentTransform);
            obj.gameObject.SetActive(false);
            return obj;
        }
    }
}
