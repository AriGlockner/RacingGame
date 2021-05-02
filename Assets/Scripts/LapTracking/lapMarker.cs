using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lapMarker : MonoBehaviour
{
    public int positionInLap;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            setPlayerPosition(positionInLap);

        else if (other.tag == "ghost")
            setGhostPosition(positionInLap);
    }

    public static void setPlayerPosition(int pos)
    {
        LapTracker.updatePosition(pos);
    }

    public static void setGhostPosition(int pos)
    {
        ghostLapTracker.updatePosition(pos);
    }
}
