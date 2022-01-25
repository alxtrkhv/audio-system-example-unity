using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class Bullet : MonoBehaviour, IPoolable
    {
        public UnitSide UnitSide { get; private set; }

        public Vector3 StartPosition { get; private set; }
        public Vector3 EndPosition { get; private set; }

        public Collider Target { get; private set; }

        public void Initialize(Vector3 start, Vector3 end, UnitSide unitSide, Collider target)
        {
            StartPosition = start;
            EndPosition = end;
            UnitSide = unitSide;
            Target = target;
        }

        public void Release()
        {
        }
    }
}
