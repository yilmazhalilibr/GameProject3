using GameProject3.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace GameProject3.Abstracts.UIs
{
    public abstract class BaseButton : MonoBehaviour
    {
        Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(HandleOnButtonClicked);
        }
        private void OnDisable()
        {
            _button.onClick.RemoveListener(HandleOnButtonClicked);
        }


        protected abstract void HandleOnButtonClicked();

    }
}

