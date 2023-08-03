using GameProject3.Abstracts.Controllers;
using GameProject3.Abstracts.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject3.States.EnemyStates
{
    public class DeadState : IState
    {
        IEnemyController _enemyController;



        public DeadState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }


        public void OnEnter()
        {
            Debug.Log($"{nameof(DeadState)} {nameof(OnEnter)}");

            _enemyController.Dead.DeadAction();
            _enemyController.Animation.DeadAnimation();
            _enemyController.transform.GetComponent<CapsuleCollider>().enabled = false;
        }

        public void OnExit()
        {
            Debug.Log($"{nameof(DeadState)} {nameof(OnExit)}");

        }

        public void Tick()
        {


        }

        public void TickFixed()
        {
        }

        public void TickLate()
        {
        }


    }

}
