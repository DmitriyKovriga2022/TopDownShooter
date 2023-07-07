using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LerpString
{
    public static IEnumerator LerpValue(float current, float target, Action<float> output, float dumpTime = 10f)
    {
        while (current != target)
        {
            current = Mathf.MoveTowards(current, target, dumpTime * Time.deltaTime);
            output(Mathf.RoundToInt(current));
            yield return null;
        }
    }
}
