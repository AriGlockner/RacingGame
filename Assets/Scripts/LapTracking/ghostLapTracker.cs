using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ghostLapTracker : MonoBehaviour
{
    [Header("Info from the lapTracker GameObject:")]
    public GameObject lapTracker;
    public int totalLaps;
    public int totalPositionsInLaps;

    [Header("CPU Position tracking")]
    public int cpuPositionInLap;
    public int cpuCurrentLap;

    public static int cpuPos;
    public static int cpuLap;

    public static bool updateVariables = false;

    void Start()
    {
        lapTracker = GameObject.FindGameObjectWithTag("lapTracking");
        totalLaps = LapTracker.maxLap;
        totalPositionsInLaps = LapTracker.maxPosition;

        cpuPositionInLap = 0;
        cpuCurrentLap = 1;
        cpuLap = 1;
    }

    void Update()
    {
        if (updateVariables)
            UpdateVariables();
    }

    void UpdateVariables()
    {
        cpuPositionInLap = cpuPos;
        cpuCurrentLap = cpuLap;

        updateVariables = false;
    }

    public static void updatePosition(int newPos)
    {
        if (newPos == cpuPos + 1)
        {
            cpuPos++;
            updateVariables = true;
        }
    }

    public static void updateLap()
    {
        if (cpuPos == LapTracker.maxPosition)
        {
            cpuLap++;

            if (cpuLap > LapTracker.maxLap)
                SceneManager.LoadScene("LoseScreen");
            
            cpuPos = 0;
            updateVariables = true;
        }
    }

    public int getLap()
    {
        return cpuLap;
    }

    public int getPos()
    {
        return cpuPos;
    }
}
