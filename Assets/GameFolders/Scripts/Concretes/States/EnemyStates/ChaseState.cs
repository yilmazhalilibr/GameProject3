using GameProject3.Abstracts.Controllers;
using GameProject3.Abstracts.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject3.States.EnemyStates
{
    public class ChaseState : IState
    {
        IEnemyController _enemyController;


        public ChaseState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }


        public void OnEnter()
        {
            Debug.Log($"{nameof(ChaseState)} {nameof(OnEnter)}");
        }

        public void OnExit()
        {
            Debug.Log($"{nameof(ChaseState)} {nameof(OnExit)}");

        }

        public void Tick()
        {
            _enemyController.Mover.MoveAction(_enemyController.Target.position, 10f);
        }

        public void TickFixed()
        {
        }

        public void TickLate()
        {
            _enemyController.Animation.MoveAnimation(_enemyController.Magnitude);
        }
    }
}

