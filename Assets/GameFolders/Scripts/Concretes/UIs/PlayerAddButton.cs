using GameProject3.Abstracts.UIs;
using GameProject3.Managers;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace GameProject3.UIs
{
    public class PlayerAddButton : BaseButton
    {
        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.IncreasePlayerCount();
        }
    }


}

