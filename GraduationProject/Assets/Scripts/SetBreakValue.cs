using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBreakValue : MonoBehaviour
{
    public static float BreakValue;
    static bool ValueNotSet = true;

    static void SetVaseBreakValue()
    {
        if (ValueNotSet)
        {
            BreakValue = Mathf.Round(Random.Range(0.01f, 1.01f) * 100f) / 100f;
            ValueNotSet = false;
        }
        Debug.Log("BreakValue = " + BreakValue);
    }

    public static float GetVaseBreakValue()
    {
        SetVaseBreakValue();
        return BreakValue;
    }
}
