using UnityEditor;
using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    [CreateAssetMenu(fileName = "New Application Context", menuName = "Application/Application Context", order = 0)]
    public class ApplicationContext : ScriptableObject
    {
        public SoundPlayer SoundPlayer { get; private set; }

        public void Init()
        {

        }
    }
}
