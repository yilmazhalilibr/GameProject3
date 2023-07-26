using GameProject3.Abstracts.Movements;
using GameProject3.Controllers;
using UnityEngine;

namespace GameProject3.Movements
{
    public class MoveWithCharacterController : IMover
    {
        CharacterController _characterController;
        public MoveWithCharacterController(PlayerController playerController)
        {
            _characterController = playerController.GetComponent<CharacterController>();
        }


        public void MoveAction(Vector3 direction, float moveSpeed)
        {
            if (direction.magnitude == 0f) return;

            Vector3 worldPosition = _characterController.transform.TransformDirection(direction);
            Vector3 movement = worldPosition * moveSpeed * Time.deltaTime;

            _characterController.Move(movement);
        }
    }

}
