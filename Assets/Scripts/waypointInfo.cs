using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointInfo : MonoBehaviour
{
    [Header("Waypoint Info")]
    public int waypointNumber;

    [Space]
    public Vector3 position;
    public Vector3 rotation;

    void Start()
    {
        position = transform.position;
        rotation = transform.eulerAngles;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "cpu")
            return;
    }
}
