using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public class SceneLifecycle : MonoBehaviour
    {
        [SerializeField]
        private GameSceneContext gameSceneContext;

        private void Start()
        {
            gameSceneContext.Initialize();
        }
    }
}
