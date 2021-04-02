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
            setPlayerPosition(positionInLap);
            return;

        }
        if (other.tag == "ghost")
        {
            setComputerPosition(positionInLap);
            return;
        }
    }

    public static void setPlayerPosition(int pos)
    {
        LapTracker.updatePosition(pos);
    }

    public static void setComputerPosition(int pos)
    {
        ghostLapTracker.updatePosition(pos);
    }
}
