using UnityEngine;
using GameProject3.Abstracts.Movements;

namespace GameProject3.Abstracts.Movements
{
    public interface IMover
    {
        public void MoveAction(Vector3 direction, float moveSpeed);

    }
}

