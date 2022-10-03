using System.Threading;
using System.Numerics;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody RocketRb;
    [SerializeField] float mainThrust = 2000f;
    [SerializeField] float rotationFactor = 200f;

    // Start is called before the first frame update
    void Start()
    {
        RocketRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            RocketRb.AddRelativeForce(UnityEngine.Vector3.up * mainThrust * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            applyRotation(rotationFactor);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            applyRotation(-rotationFactor);
        }
    }

    void applyRotation(float rotationThisFrame)
    {
        RocketRb.freezeRotation = true;
        transform.Rotate(UnityEngine.Vector3.forward * rotationThisFrame * Time.deltaTime);
        RocketRb.freezeRotation = false;
    }
}
