using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float upForce = 10f;
    [SerializeField] float rotationForce = 10f;
    [SerializeField] ParticleSystem particles;

    Rigidbody rb;
    AudioSource thrust;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thrust = GetComponent<AudioSource>();        
    }

    // Update is called once per frame
    void Update()
    {
        ReadInputUp();
        ReadInputRotate();
    }

    void ReadInputUp()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * upForce * Time.deltaTime);

            particles.Play();
            
            if (!thrust.isPlaying)
            {
                thrust.Play();
            }
        }
        else
        {
            thrust.Stop();
            particles.Stop();
        }
    }

    void ReadInputRotate()
    {
        rb.freezeRotation = true; 

        if (Input.GetKey(KeyCode.A))
        {
            rb.transform.Rotate(Vector3.forward * rotationForce * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.transform.Rotate(-Vector3.forward * rotationForce * Time.deltaTime);
        }

        rb.freezeRotation = false;
    }
}
