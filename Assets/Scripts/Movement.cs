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
    [SerializeField] float mainThrust = 100f;

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
            UnityEngine.Debug.Log("Pressed A - Rotating Left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            UnityEngine.Debug.Log("Pressed D - Rotating Right");
        }
    }
}
