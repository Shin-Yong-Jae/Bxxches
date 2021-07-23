using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class ExtensionDebug
{
    public static void Log(this object value)
    {
#if UNITY_EDITOR
        Debug.Log(value);
#endif
    }

    public static void LogError(this object value)
    {
#if UNITY_EDITOR
        Debug.LogError(value);
#endif
    }
}
