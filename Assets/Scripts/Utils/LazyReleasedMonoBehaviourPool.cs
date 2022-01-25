using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class LazyReleasedMonoBehaviourPool<TPooledObject> : MonoBehaviourPool<TPooledObject> where TPooledObject : MonoBehaviour, ILazyPoolable
    {
        private List<TPooledObject> activeObjects;

        public LazyReleasedMonoBehaviourPool(int size, TPooledObject prefab, Transform parentTransform) : base(size, prefab, parentTransform)
        {
            activeObjects = new List<TPooledObject>(size);
        }

        public override TPooledObject Get()
        {
            TPooledObject obj;

            if (inactiveObjects.Count > 0) {
                obj = inactiveObjects.Pop();
                activeObjects.Add(obj);
                return obj;
            }

            var readyForReleaseObj = activeObjects.FirstOrDefault(x => x.IsReadyForRelease);

            if (readyForReleaseObj != null) {
                obj = readyForReleaseObj;
                obj.Release();
            } else {
                obj = InitializeObject();
            }

            return obj;
        }

        public override bool Release(TPooledObject obj)
        {
            var hasBeenReleased = base.Release(obj);

            if (hasBeenReleased) {
                activeObjects.Remove(obj);
            }

            return hasBeenReleased;
        }
    }
}
