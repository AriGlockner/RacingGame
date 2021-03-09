using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayLap : MonoBehaviour
{
    public Text currentLap;
    static bool updateText = false;

    void Start()
    {
        currentLap.text = "Lap: " + LapTracker.lap.ToString();
    }

    void Update()
    {
        if (updateText)
            setText();

    }

    void setText()
    {
        currentLap.text = "Lap: " + LapTracker.lap.ToString();
        updateText = false;
    }

    public static void updateLap()
    {
        updateText = true;
    }
}
