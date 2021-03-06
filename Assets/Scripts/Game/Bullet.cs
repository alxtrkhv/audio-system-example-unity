using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class Bullet : MonoBehaviour, IPoolable
    {
        public UnitSide UnitSide { get; private set; }

        public Vector3 EndPosition { get; private set; }

        public Collider Target { get; private set; }

        public void Initialize(Vector3 start, Vector3 end, UnitSide unitSide, Collider target)
        {
            EndPosition = end;
            UnitSide = unitSide;
            Target = target;

            transform.position = start;
        }

        public void Release()
        {
            gameObject.SetActive(false);
        }
    }
}
