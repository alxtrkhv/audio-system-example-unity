using UnityEngine;
using UnityEngine.Audio;

namespace Alxtrkhv.AudioSystem
{
    [CreateAssetMenu(fileName = "New Snapshot Group", menuName = "Audio/Snapshot Group")]
    public class SnapshotGroup : ScriptableObject
    {
        [SerializeField]
        private AudioMixer mixer;

        [SerializeField]
        private AudioMixerSnapshot[] snapshots;

        [SerializeField]
        private float[] priorities;

        private float[] weights;
        private int[] counters;

        public void Initialize()
        {
            weights = new float[snapshots.Length];
            counters = new int[snapshots.Length];
        }

        public void TriggerUpdate(float time)
        {
            mixer.TransitionToSnapshots(snapshots, weights, time);
        }

        public void IncrementSoundCounter(int index)
        {
            counters[index]++;
            weights[index] = priorities[index];
        }

        public void DecrementSoundCounter(int index)
        {
            counters[index]--;

            if (counters[index] == 0) {
                weights[index] = 0;
            }
        }
    }
}
