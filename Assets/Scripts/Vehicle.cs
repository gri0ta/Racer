using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{

    public float maxSpeed = 10f;
    public float maxReverseSpeed = 5f;
    public float acceleration = 5f;
    public float brakeAcceleration = 5f;
    public float turnSpeed = 10f;
    AudioSource engineSound;
    //public ParticleSystem driftParticles;
    public GameObject driftParticle;
    public Rigidbody rb;
    
    public AnimationCurve pitchCurve;
    public Vector3 localVelocity; //local velocity yra kaip mato musu masina is priekio

    private void Start()
    {
        engineSound = GetComponent<AudioSource>();
        //driftParticles = gameObject.GetComponent<ParticleSystem>();
    }
    public void Update()
    {
        print(rb.velocity.magnitude * 3.6f);
        var speedRatio = rb.velocity.magnitude / maxSpeed;
        engineSound.pitch = pitchCurve.Evaluate(speedRatio);

        var localVelocity = transform.InverseTransformVector(rb.velocity);

        if (localVelocity.x < -1 || localVelocity.x > 1 )
        {
            //driftParticles.Play();
            driftParticle.SetActive(true);
            print("drift");
        }

        //DRAG
        rb.velocity += transform.forward * localVelocity.z * 0.1f * Time.deltaTime;
        rb.velocity += transform.right * localVelocity.x * 1f * Time.deltaTime;
    }

    public void Brake()
    {
        if (localVelocity.z < maxReverseSpeed) return; //velocity gali but minusinis
        rb.velocity += transform.forward * -brakeAcceleration * Time.deltaTime;
    }

    public void Gas()
    { 
        if (localVelocity.z > maxSpeed) return;
        rb.velocity += transform.forward * acceleration * Time.deltaTime;
    }

    public void Turn(float amount)
    {
        amount = Mathf.Clamp(amount, 1, -1);
        transform.Rotate(0, amount * turnSpeed * Time.deltaTime, 0) ;
    }
}
