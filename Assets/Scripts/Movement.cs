using System.Threading;
using System.Numerics;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float mainThrust = 2000f;
    [SerializeField] float rotationFactor = 200f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem leftThrusterParticles;
    [SerializeField] ParticleSystem rightThrusterParticles;

    Rigidbody RocketRb;
    AudioSource audioSource;
    bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        RocketRb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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

            if(!audioSource.isPlaying) 
            {
                audioSource.PlayOneShot(mainEngine);
            }

            if(!mainEngineParticles.isPlaying)
            {
                mainEngineParticles.Play();
            }
        }
        else
        {
            audioSource.Stop();
            mainEngineParticles.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            applyRotation(rotationFactor);
            if (!leftThrusterParticles.isPlaying)
            {
                leftThrusterParticles.Play();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            applyRotation(-rotationFactor);
            if (!rightThrusterParticles.isPlaying)
            {
                rightThrusterParticles.Play();
            }
        }
        else
        {
            rightThrusterParticles.Stop();
            leftThrusterParticles.Stop();
        }
    }

    void applyRotation(float rotationThisFrame)
    {
        RocketRb.freezeRotation = true;
        transform.Rotate(UnityEngine.Vector3.forward * rotationThisFrame * Time.deltaTime);
        RocketRb.freezeRotation = false;
    }
}
