using GameProject3.Abstracts.Inputs;
using GameProject3.Abstracts.Movements;
using GameProject3.Animations;
using GameProject3.Movements;
using UnityEngine;

namespace GameProject3.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Informations")]
        [SerializeField] float _moveSpeed = 10f;


        IInputReader _input;
        IMover _mover;

        Vector3 _direction;

        CharacterAnimation _animation;



        private void Awake()
        {
            _input = GetComponent<IInputReader>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
        }

        private void Update()
        {
            _direction = _input.Direction;
        }

        private void FixedUpdate()
        {
            _mover.MoveAction(_direction, _moveSpeed);
        }

        private void LateUpdate()
        {
            _animation.MoveAnimation(_direction.magnitude);
        }


    }

}

