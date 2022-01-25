using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class Bullet : MonoBehaviour
    {
        public UnitSide UnitSide { get; private set; }

        public Vector3 StartPosition { get; private set; }
        public Vector3 EndPosition { get; private set; }

        public void Initialize(Vector3 start, Vector3 end, UnitSide unitSide)
        {
            StartPosition = start;
            EndPosition = end;
            UnitSide = unitSide;
        }
    }
}
