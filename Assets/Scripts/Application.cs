using UnityEngine;
using UnityEngine.SceneManagement;

namespace Alxtrkhv.AudioSystem
{
    public class Application : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField]
        private int mainSceneIndex;

        [Header("Contexts")]
        [SerializeField]
        private ApplicationContext applicationContext;

        [Header("Screen references")]
        [SerializeField]
        private GameObject loadingScreen;

        private void Start()
        {
            applicationContext.Init(this);

            SceneManager.LoadSceneAsync(mainSceneIndex, LoadSceneMode.Additive)
                        .completed += OnLoadingCompleted;
        }

        private void OnLoadingCompleted(AsyncOperation asyncOperation)
        {
            var scene = SceneManager.GetSceneByBuildIndex(mainSceneIndex);
            SceneManager.SetActiveScene(scene);
            loadingScreen.SetActive(false);
        }
    }
}
