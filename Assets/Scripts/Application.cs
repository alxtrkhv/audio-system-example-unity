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

            var loadingOperation = SceneManager.LoadSceneAsync(mainSceneIndex, LoadSceneMode.Additive);

            loadingOperation.allowSceneActivation = true;

            loadingOperation.completed += OnLoadingCompleted;
        }

        private void OnLoadingCompleted(AsyncOperation asyncOperation)
        {
            asyncOperation.completed -= OnLoadingCompleted;

            loadingScreen.SetActive(false);
        }
    }
}
