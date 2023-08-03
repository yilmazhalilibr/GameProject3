using GameProject3.Abstracts.Combats;
using GameProject3.Abstracts.Controllers;
using GameProject3.Abstracts.Inputs;
using GameProject3.Abstracts.Movements;
using GameProject3.Animations;
using GameProject3.Combats;
using GameProject3.Movements;
using UnityEngine;

namespace GameProject3.Controllers
{
    public class PlayerController : MonoBehaviour, IEntityController
    {
        [Header("Movement Informations")]
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] float _turnSpeed = 10f;
        [SerializeField] Transform _turnTransform;


        IInputReader _input;
        IRotator _xRotator;
        IRotator _yRotator;
        IMover _mover;
        IHealth _health;
        Vector3 _direction;
        CharacterAnimation _animation;
        InventoryController _inventoryController;

        public Transform TurnTransform => _turnTransform;

        private void Awake()
        {
            _input = GetComponent<IInputReader>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
            _xRotator = new RotatorX(this);
            _yRotator = new RotatorY(this);
            _inventoryController = GetComponent<InventoryController>();
            _health = GetComponent<Health>();
        }
        private void OnEnable()
        {
            _health.OnDead += () => _animation.DeadAnimation("death");
        }
        private void OnDisable()
        {
            _health.OnDead -= () => _animation.DeadAnimation("death");

        }

        private void Update()
        {
            if (_health.isDead) return;

            _direction = _input.Direction;
            _xRotator.RotationAction(_input.Rotation.x, _turnSpeed);
            _yRotator.RotationAction(_input.Rotation.y, _turnSpeed);

            if (_input.isAttackButtonPress)
            {
                _inventoryController.CurrentWeapon.Attack();

            }
            if (_input.IsInventoryButtonPressed)
            {
                _inventoryController.ChangeWeapon();
            }

        }

        private void FixedUpdate()
        {
            if (_health.isDead) return;

            _mover.MoveAction(_direction, _moveSpeed);

        }

        private void LateUpdate()
        {
            if (_health.isDead) return;

            _animation.MoveAnimation(_direction.magnitude);
            _animation.AttackAnimation(_input.isAttackButtonPress);
        }


    }

}

