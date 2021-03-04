using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newLap : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LapTracker.updateLap();
            return;

        }
    }

}
