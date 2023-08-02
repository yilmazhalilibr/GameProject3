using GameProject3.Abstracts.Combats;
using GameProject3.Abstracts.Controllers;
using GameProject3.Abstracts.Movements;
using GameProject3.Animations;
using GameProject3.Movements;
using GameProject3.States;
using GameProject3.States.EnemyStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GameProject3.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {

        IMover _mover;
        IHealth _health;
        CharacterAnimation _animation;
        NavMeshAgent _navMeshAgent;
        InventoryController _inventoryController;
        Transform _playerTransform;
        StateMachine _stateMachine;


        public bool CanAttack => Vector3.Distance(_playerTransform.position, this.transform.position) <= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity == Vector3.zero;
        public IMover Mover { get; private set; }

        private void Awake()
        {
            Mover = new MoveWithNavMesh(this);
            _animation = new CharacterAnimation(this);
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health = GetComponent<IHealth>();
            _inventoryController = GetComponent<InventoryController>();
            _stateMachine = new StateMachine();
        }

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerController>().transform;

            AttackState attackState = new AttackState();
            ChaseState chaseState = new ChaseState(this, _playerTransform);
            DeadState deadState = new DeadState();

            _stateMachine.AddState(chaseState, attackState, () => CanAttack);
            _stateMachine.AddState(attackState, chaseState, () => !CanAttack);
            _stateMachine.AddAnyState(deadState, () => _health.isDead);

            _stateMachine.SetState(chaseState);
        }

        private void Update()
        {
            if (_health.isDead) return;


            _stateMachine.Tick();
        }
        private void FixedUpdate()
        {
            if (CanAttack)
            {
                _inventoryController.CurrentWeapon.Attack();
            }
        }

        private void LateUpdate()
        {
            _animation.MoveAnimation(_navMeshAgent.velocity.magnitude);
            _animation.AttackAnimation(CanAttack);

        }
    }

}
