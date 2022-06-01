using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tween
{
    public static float Do(float from, float to, float t, Easing.Functions easing)
    {
        return from + ((to - from) * Easing.Interpolate(t, easing));
    }
}