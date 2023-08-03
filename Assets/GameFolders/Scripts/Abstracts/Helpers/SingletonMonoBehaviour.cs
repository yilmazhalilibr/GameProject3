using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject3.Abstracts.Helpers
{

    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set; }

        protected void SetSingeltonThisGameObject(T instance)
        {

            if (Instance == null)
            {
                Instance = instance;
                DontDestroyOnLoad(this.gameObject);

            }
            else
            {
                Destroy(this.gameObject);
            }

        }


    }
}

