using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtensions
{
    public static Vector2 Resize(this Vector2 vector, float length)
    {
        return (vector * length) / vector.magnitude;
    }

    public static Vector3 Resize(this Vector3 vector, float length)
    {
        return (vector * length) / vector.magnitude;
    }

    public static Vector3 ToVector3XZ(this Vector2 vector)
    {
        return new Vector3(vector.x, 0, vector.y);
    }
}
