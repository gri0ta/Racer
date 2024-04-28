using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brains : MonoBehaviour
{
    Vehicle vehicle;

    public void Start()
    {
        vehicle = GetComponent<Vehicle>();
    }

    public void Update()
    {
        vehicle.Gas();
        vehicle.Turn(Random.Range(-1f,1f));
    }
}

