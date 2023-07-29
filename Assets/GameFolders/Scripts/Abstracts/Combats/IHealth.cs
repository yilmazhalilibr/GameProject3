using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject3.Abstracts.Combats
{
    public interface IHealth
    {
        bool isDead { get; }

        void TakeDamage(int damage);
    }
}

