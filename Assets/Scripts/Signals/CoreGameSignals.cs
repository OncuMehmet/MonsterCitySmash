using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoreGameSignals : MonoSingleton<CoreGameSignals>
{
    public UnityAction onPlay = delegate { };
    public UnityAction onReset = delegate { };
}
