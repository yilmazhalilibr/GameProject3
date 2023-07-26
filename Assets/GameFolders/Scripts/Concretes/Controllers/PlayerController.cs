using GameProject3.Abstracts.Inputs;
using GameProject3.Abstracts.Movements;
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




        private void Awake()
        {
            _input = GetComponent<IInputReader>();
            _mover = new MoveWithCharacterController(this);
        }

        private void Update()
        {
            _direction = _input.Direction;
        }

        private void FixedUpdate()
        {
            _mover.MoveAction(_direction, _moveSpeed);
        }



    }

}

