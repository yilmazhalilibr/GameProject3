using GameProject3.Abstracts.Combats;
using GameProject3.Abstracts.Controllers;
using GameProject3.Abstracts.Movements;
using GameProject3.Animations;
using GameProject3.Combats;
using GameProject3.Managers;
using GameProject3.Movements;
using GameProject3.States;
using GameProject3.States.EnemyStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GameProject3.Controllers
{
    public class EnemyController : MonoBehaviour, IEnemyController
    {

        IHealth _health;
        NavMeshAgent _navMeshAgent;
        StateMachine _stateMachine;


        public bool CanAttack => Vector3.Distance(Target.position, this.transform.position) <= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity == Vector3.zero;
        public IMover Mover { get; private set; }

        public InventoryController Inventory { get; private set; }

        public CharacterAnimation Animation { get; private set; }
        public Transform Target { get; set; }
        public Dead Dead { get; private set; }

        public float Magnitude => _navMeshAgent.velocity.magnitude;


        private void Awake()
        {
            Mover = new MoveWithNavMesh(this);
            Animation = new CharacterAnimation(this);
            Inventory = GetComponent<InventoryController>();

            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health = GetComponent<IHealth>();
            _stateMachine = new StateMachine();

            Dead = GetComponent<Dead>();
        }

        private void Start()
        {
            Target = FindObjectOfType<PlayerController>().transform;

            AttackState attackState = new AttackState(this);
            ChaseState chaseState = new ChaseState(this);
            DeadState deadState = new DeadState(this);

            _stateMachine.AddState(chaseState, attackState, () => CanAttack);
            _stateMachine.AddState(attackState, chaseState, () => !CanAttack);
            _stateMachine.AddAnyState(deadState, () => _health.isDead);

            _stateMachine.SetState(chaseState);
        }

        private void Update()
        {
            _stateMachine.Tick();
        }
        private void FixedUpdate()
        {
            _stateMachine.TickFixed();
        }

        private void LateUpdate()
        {
            _stateMachine.TickLate();

        }
        private void OnDestroy()
        {
            EnemyManager.Instance.RemoveEnemyController(this);
        }
    }

}
