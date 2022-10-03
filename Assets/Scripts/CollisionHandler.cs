using System.Diagnostics;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Respawn":
                UnityEngine.Debug.Log("This is friendly");
                break;
            case "Finish":
                UnityEngine.Debug.Log("This is Finish");
                break;    
            case "Fuel":
                UnityEngine.Debug.Log("This is Fuel");
                break;       
        }
    }
}
