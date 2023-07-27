﻿using UnityEngine;

namespace GameProject3.Abstracts.Inputs
{
    public interface IInputReader
    {
        Vector3 Direction { get; }
        Vector2 Rotation { get; }
    }
}

