using GameProject3.Abstracts.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject3.Abstracts.Controllers
{
    public interface IEntityController
    {
        public Transform transform { get; }
    }
}

