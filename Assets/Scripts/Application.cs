using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Alxtrkhv.AudioSystem
{
    public class Application : MonoBehaviour
    {
        [Header("Contexts")]
        [SerializeField]
        private ApplicationContext applicationContext;

        [Header("Scene References")]
        [SerializeField]
        private SceneAsset mainScene;

        [Header("Screen references")]
        [SerializeField]
        private GameObject loadingScreen;

        private void Start()
        {
            applicationContext.Init(this);

            var loadingOperation = SceneManager.LoadSceneAsync(mainScene.name, LoadSceneMode.Additive);

            loadingOperation.completed += OnLoadingCompleted;
        }

        private void OnLoadingCompleted(AsyncOperation asyncOperation)
        {
            loadingScreen.SetActive(false);
        }
    }
}
