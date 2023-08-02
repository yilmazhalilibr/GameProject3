using GameProject3.Abstracts.Inputs;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameProject3.Inputs
{
    public class InputReader : MonoBehaviour, IInputReader
    {
        public Vector3 Direction { get; private set; }
        public Vector2 Rotation { get; private set; }

        public bool isAttackButtonPress { get; private set; }

        public bool IsInventoryButtonPressed { get; private set; }

        int _index = 0;
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

        public void OnInventoryPressed(InputAction.CallbackContext context)
        {
            if (IsInventoryButtonPressed && context.action.triggered) return;

            StartCoroutine(WaitOnFrameAsync());
        }

        IEnumerator WaitOnFrameAsync()
        {
            IsInventoryButtonPressed = true && _index % 2 == 0;
            yield return new WaitForEndOfFrame();
            IsInventoryButtonPressed = false;
            _index++;
        }
    }
}

