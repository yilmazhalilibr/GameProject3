using GameProject3.Abstracts.Controllers;
using GameProject3.Abstracts.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject3.States.EnemyStates
{
    public class ChaseState : IState
    {
        IEntityController _entityController;

        Transform _targetTransform;

        public ChaseState(IEntityController entityController,Transform target)
        {
            _entityController = entityController;
            _targetTransform = target;
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
            _entityController.Mover.MoveAction(_targetTransform.position, 10f);
        }
    }
}

