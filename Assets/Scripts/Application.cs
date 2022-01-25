using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Alxtrkhv.AudioSystem
{
    public class Application : MonoBehaviour
    {
        [Header("Scene References")]
        [SerializeField]
        private SceneAsset mainScene;

        [Header("Screen references")]
        [SerializeField]
        private GameObject loadingScreen;

        private void Start()
        {
            var loadingOperation = SceneManager.LoadSceneAsync(mainScene.name, LoadSceneMode.Additive);

            loadingOperation.completed += OnLoadingCompleted;
        }

        private void OnLoadingCompleted(AsyncOperation asyncOperation)
        {
            loadingScreen.SetActive(false);
        }
    }
}
