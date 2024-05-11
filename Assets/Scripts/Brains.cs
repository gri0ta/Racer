using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brains : MonoBehaviour
{
    public Transform target;
    Vehicle vehicle;
    public float minTurnAngle = 3;
    Path path;

    public void Start()
    {
        vehicle = GetComponent<Vehicle>();
        path = FindObjectOfType<Path>();
        target = path.GetClosestPoint(transform.position);
    }

    public void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position,target.position);
        if (distanceToTarget < 3)
        {
            target = path.GetNextPoint(transform.position);
        }
        Debug.DrawLine(transform.position, target.position, Color.red); 
        Vector3 targetDir = target.position - transform.position;
        targetDir.Normalize();
        float angle = Vector3.SignedAngle(transform.forward,targetDir,Vector3.up);
        print(angle);

        vehicle.Gas();
        if (angle>minTurnAngle || angle<-minTurnAngle)
        {
            vehicle.Turn(angle);
        }
        
    }
}

