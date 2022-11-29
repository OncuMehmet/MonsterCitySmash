using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData
{
    public PlayerMovementData MovementData;
}

[Serializable]
public class PlayerMovementData
{
    public float SidewaysSpeed = 5f;
    public float ZSpeed = 0f;
}
