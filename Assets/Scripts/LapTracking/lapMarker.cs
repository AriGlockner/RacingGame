using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lapMarker : MonoBehaviour
{
    public int positionInLap;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            setPosition(positionInLap);
            return;

        }
    }

    public static void setPosition(int pos)
    {
        LapTracker.updatePosition(pos);
    }
}
