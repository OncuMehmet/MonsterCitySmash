using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class InputData
{
    public float HorizontalInputSpeed = 3f;
    public Vector2 ClampSides = new Vector2(-9, 9);
    public float ClampSpeed = 0.007f;
}
