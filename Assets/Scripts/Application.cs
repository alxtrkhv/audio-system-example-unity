using System;
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

        private void Awake()
        {
            applicationContext.Init(this);
        }

        private void Start()
        {
            if (SceneManager.GetActiveScene().buildIndex != 0) {
                return;
            }

            LoadMainScene();
        }

        private void LoadMainScene()
        {
            var loadingOperation = SceneManager.LoadSceneAsync(mainSceneIndex, LoadSceneMode.Additive);

            loadingOperation.allowSceneActivation = true;

            loadingOperation.completed += OnMainSceneLoadingCompleted;
        }

        private void OnMainSceneLoadingCompleted(AsyncOperation asyncOperation)
        {
            asyncOperation.completed -= OnMainSceneLoadingCompleted;

            loadingScreen.SetActive(false);
        }
    }
}
