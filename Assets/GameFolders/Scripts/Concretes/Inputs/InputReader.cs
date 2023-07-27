using GameProject3.Abstracts.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameProject3.Inputs
{
    public class InputReader : MonoBehaviour, IInputReader
    {
        public Vector3 Direction { get; private set; }
        public Vector2 Rotation { get; private set; }

        public bool isAttackButtonPress { get; private set; }

        public void OnMove(InputAction.CallbackContext context)
        {
            var OldDirection = context.ReadValue<Vector2>();
            Direction = new Vector3(OldDirection.x, 0f, OldDirection.y);
        }

        public void OnRotator(InputAction.CallbackContext context)
        {
            Rotation = context.ReadValue<Vector2>();
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            isAttackButtonPress = context.ReadValueAsButton();
        }

    }
}

