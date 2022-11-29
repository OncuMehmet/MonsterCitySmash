using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelSignals : MonoSingleton<LevelSignals>
{

    public UnityAction onLevelInitialize = delegate { };
    public UnityAction onClearActiveLevel = delegate { };
    public UnityAction onLevelFailed = delegate { };
    public UnityAction onLevelSuccessful = delegate { };
    public UnityAction onNextLevel = delegate { };
    public UnityAction onRestartLevel = delegate { };
}
