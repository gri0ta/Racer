using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vehicle vehicle;

    private void Start()
    {
        vehicle = GetComponent<Vehicle>();
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            vehicle.Gas();
        }

        if (Input.GetKey(KeyCode.S))
        {
            vehicle.Brake();
        }

        var turnSide = Input.GetAxis("Horizontal");
        if (turnSide !=0)
        {
            vehicle.Turn(turnSide);
        }
    }
}
