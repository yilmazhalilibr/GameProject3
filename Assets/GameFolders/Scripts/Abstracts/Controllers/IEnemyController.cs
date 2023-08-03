using GameProject3.Abstracts.Movements;
using GameProject3.Animations;
using GameProject3.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject3.Abstracts.Controllers
{
    public interface IEnemyController : IEntityController
    {
        IMover Mover { get; }
        InventoryController Inventory { get; }
        CharacterAnimation Animation { get; }
        Transform Target { get; set; }
        float Magnitude { get; }
    }
}

