using GameProject3.Abstracts.Movements;
using GameProject3.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject3.Movements
{
    public class RotatorX : IRotator
    {
        PlayerController _playerController;

        public RotatorX(PlayerController playerController)
        {
            _playerController = playerController;
        }


        public void RotationAction(float direction, float speed)
        {
            _playerController.transform.Rotate(Vector3.up * direction * Time.deltaTime * speed);
        }
    }
}

