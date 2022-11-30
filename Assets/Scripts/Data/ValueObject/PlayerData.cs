using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData
{
    public PlayerMovementData PlayerMovementData;
}

[Serializable]
public class PlayerMovementData
{
    public float SidewaysSpeed = 5f;
    public float ZSpeed = 0f;
}
