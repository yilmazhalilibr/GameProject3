using GameProject3.Abstracts.Combats;
using GameProject3.Abstracts.Controllers;
using GameProject3.Abstracts.Inputs;
using GameProject3.Abstracts.Movements;
using GameProject3.Animations;
using GameProject3.Combats;
using GameProject3.Managers;
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
        [SerializeField] Transform _ribTransform;

        [Header("Uis")]
        [SerializeField] GameObject _gameOverPanel;

        IInputReader _input;
        IRotator _xRotator;
        IRotator _yRotator;
        IRotator _ribRotator;
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
            _ribRotator = new RibRotator(_ribTransform);
            _inventoryController = GetComponent<InventoryController>();
            _health = GetComponent<Health>();
        }
        private void OnEnable()
        {
            _health.OnDead += () =>
            {
                _animation.DeadAnimation("death");
                _gameOverPanel.SetActive(true);
            };

            EnemyManager.Instance.Targets.Add(this.transform);

        }
        private void OnDisable()
        {
            _health.OnDead -= () => _animation.DeadAnimation("death");

            EnemyManager.Instance.Targets.Remove(this.transform);


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

            _ribRotator.RotationAction(_input.Rotation.y * -1, _turnSpeed);
        }


    }

}

