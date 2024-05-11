using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    private Transform[] points;

    public Transform GetNextPoint(Vector3 position)
    {
        var closest = GetClosestPoint(position);
        return points[1];
    }

    public void GetClosestPoint(Vector3 point)
    {
        float minDistance = float.MaxValue;
        Transform closestPoint= null;
        for (int i = 0; i < points.Length; i++)
        {
            var distance = Vector3.Distance(point, points[i].position);
            if (distance<minDistance)
            {
                minDistance= distance;
                closestPoint = points[i];
            }
        }
        return closestPoint;
    }

    public void Start()
    {
        points = GetComponentsInChildren<Transform>()[1..];
    }
}
