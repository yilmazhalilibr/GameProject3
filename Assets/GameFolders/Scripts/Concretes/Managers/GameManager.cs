using GameProject3.Abstracts.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject3.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        private void Awake()
        {
            SetSingeltonThisGameObject(this);
        }





    }
}

