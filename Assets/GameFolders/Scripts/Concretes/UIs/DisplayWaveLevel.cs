using GameProject3.Managers;
using TMPro;
using UnityEngine;

namespace GameProject3.UIs
{
    public class DisplayWaveLevel : MonoBehaviour
    {
        TMP_Text _levelText;

        private void Awake()
        {
            _levelText = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            GameManager.Instance.OnNextWave += HandleOnNextWave;
        }
        private void OnDisable()
        {
            GameManager.Instance.OnNextWave -= HandleOnNextWave;

        }

        private void HandleOnNextWave(int levelValue)
        {
            _levelText.text = levelValue.ToString();

        }


    }
}

