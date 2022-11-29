using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputSignals : MonoSingleton<InputSignals>
{
    public UnityAction<bool> onSidewaysEnable = delegate { };
    public UnityAction<HorizontalInputParams> onInputDragged = delegate { };
}
