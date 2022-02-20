using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Hit Friend");
                break;
            case "Finish":
                Debug.Log("Hit Finish");
                break;
            default:
                Debug.Log("DEAD");
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Fuel":
                Debug.Log("Hit Fuel");
                break;
        }
    }
}
