using GameProject3.Abstracts.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject3.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        IInputReader _input;

        private void Awake()
        {
            _input = GetComponent<IInputReader>();
        }

        private void Update()
        {

        }



    }

}

