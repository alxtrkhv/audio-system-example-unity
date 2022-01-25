using System.Collections.Generic;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class ObjectPool<TPoolable> : IObjectPool<TPoolable> where TPoolable : IPoolable, new()
    {
        private Stack<TPoolable> inactiveObjects;

        public ObjectPool(int size)
        {
            inactiveObjects = new Stack<TPoolable>(size);

            for (var i = 0; i < size; i++) {
                var obj = InitializeObject();
                inactiveObjects.Push(obj);
            }
        }

        public TPoolable Get()
        {
            if (inactiveObjects.Count > 0) {
                return inactiveObjects.Pop();
            }

            return InitializeObject();
        }

        public bool Release(TPoolable obj)
        {
            if (!inactiveObjects.Contains(obj)) {
                obj.Release();
                inactiveObjects.Push(obj);
                return true;
            }

            Debug.LogWarning($"{nameof(obj)} object has already been released");
            return false;
        }

        private TPoolable InitializeObject()
        {
            return new TPoolable();
        }
    }
}
