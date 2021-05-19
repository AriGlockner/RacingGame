using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newLap : MonoBehaviour
{
    [Header("Waypoint Info")]
    public Vector3 position;
    public Vector3 rotation;


    void Start()
    {
        position = transform.position;
        rotation = transform.eulerAngles;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LapTracker.updateLap();
            return;
        }

        if (other.tag == "ghost")
        {
            ghostLapTracker.updateLap();
            return;
        }

        if (other.tag == "cpu")
        {
            other.GetComponent<resetCPUposition>().updateWaypoint(0, position, rotation);
        }
    }

}
