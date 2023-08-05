using GameProject3.Abstracts.UIs;
using GameProject3.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameProject3.UIs
{
    public class ReturnButton : BaseButton
    {
        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.LoadReturnMenu();
        }

    }

}
