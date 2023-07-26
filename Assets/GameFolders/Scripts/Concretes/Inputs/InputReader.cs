using GameProject3.Abstracts.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameProject3.Inputs
{
    public class InputReader : MonoBehaviour, IInputReader
    {
        public Vector2 Direction { get; private set; }

        public void OnMove(InputAction.CallbackContext context)
        {
            var OldDirection = context.ReadValue<Vector2>();
            Direction = new Vector3(OldDirection.x, 0f, OldDirection.y);
        }
    }
}

