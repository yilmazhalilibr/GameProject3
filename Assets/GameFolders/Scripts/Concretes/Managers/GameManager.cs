using GameProject3.Abstracts.Helpers;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameProject3.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        [SerializeField] int _waveMaxCount = 100;

        public bool IsWaveFinished => _waveMaxCount <= 0;

        private void Awake()
        {
            SetSingeltonThisGameObject(this);
        }

        public void LoadLevel(string name)
        {
            StartCoroutine(LoadLevelAsync(name));
        }

        private IEnumerator LoadLevelAsync(string name)
        {
            yield return SceneManager.LoadSceneAsync(name);
        }

        public void DecreaseWaveCount()
        {
            if (IsWaveFinished) return;
            _waveMaxCount--;
        }

    }
}

