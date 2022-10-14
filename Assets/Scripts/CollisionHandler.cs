using System.Security.Cryptography;
using System.ComponentModel;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;

    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    AudioSource audioSource;

    bool isTransitioning = false;
    bool collisionDisabled = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            NextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning || collisionDisabled) { return; }
        
        switch (other.gameObject.tag)
            {
                case "Respawn":
                    UnityEngine.Debug.Log("This is friendly");
                    break;
                case "Finish":
                    StartSuccessSequence(1f);
                    break;    
                case "Fuel":
                    UnityEngine.Debug.Log("This is Fuel");
                    break; 
                default:
                    StartCrashSequence(1f);
                    break;          
            }
        
    }

    void StartCrashSequence(float delay)
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delay);
    }

    void StartSuccessSequence(float delay)
    {
        isTransitioning = true;
        audioSource.Stop();
        successParticles.Play();
        audioSource.PlayOneShot(success);
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel", delay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = ++currentSceneIndex;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
