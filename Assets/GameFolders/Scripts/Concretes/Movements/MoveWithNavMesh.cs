using GameProject3.Abstracts.Controllers;
using GameProject3.Abstracts.Movements;
using GameProject3.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GameProject3.Movements
{
    public class MoveWithNavMesh : IMover
    {
        NavMeshAgent _navMeshAgent;

        public MoveWithNavMesh(IEntityController entityController)
        {
            _navMeshAgent = entityController.transform.GetComponent<NavMeshAgent>();
        }

        public void MoveAction(Vector3 direction, float moveSpeed)
        {
            _navMeshAgent.SetDestination(direction);
        }
    }

}
