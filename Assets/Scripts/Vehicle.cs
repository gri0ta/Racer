using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{

    public float speed = 10f;
    public float turnSpeed = 10f;
    AudioSource engineSound;
    public Rigidbody rb;
    public AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void Update()
    {
        print(rb.velocity.magnitude * 3.6f);
        engineSound.pitch = 1 + rb.velocity.magnitude * 0.1f;
    }

    public void Brake()
    {

    }

    public void Gas()
    {
        print("Gas");
        //rb.velocity = transform.forward *speed;
        rb.velocity += transform.forward * speed * Time.deltaTime;
    }

    public void Turn(float amount)
    {
        transform.Rotate(0, amount * turnSpeed * Time.deltaTime, 0) ;
    }
}
