using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : SingletonMonoBase<InGameManager>
{
    public bool isTutorialEnd = false;

    public bool isGameCleared = false;

    public void Reset()
    {
        isGameCleared = false;
    }
}