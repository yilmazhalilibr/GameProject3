using GameProject3.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace GameProject3.UIs
{
    public class StartButton : MonoBehaviour
    {
        Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(HandleOnButtonOnClick);
        }
        private void OnDisable()
        {
            _button.onClick.RemoveListener(HandleOnButtonOnClick);
        }

        private void HandleOnButtonOnClick()
        {
            GameManager.Instance.LoadLevel("Game");
        }


    }
}

