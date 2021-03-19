using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LapTracker : MonoBehaviour
{
    //Non-Static Variables
    [Header("Laps:")]
    public int currentLap;
    public int totalLaps;

    [Header("Position In Lap:")]
    public int positionInLap;
    public int maxPositionInLap;

    //Static variables
    //Lap
    public static int lap = 1;
    public static int maxLap;

    //Position
    public static int position = 0;
    public static int maxPosition;

    //Update Variables
    public static bool updateVariables = false;

    void Start()
    {
        maxLap = totalLaps;
        maxPosition = maxPositionInLap;     
    }

    void Update()
    {
        //Update Variables when required
        if (updateVariables)
            updateLocation();
    }

    void updateLocation()
    {
        //Sets the non-static variables equal to the static variables
        currentLap = lap;
        positionInLap = position;
        updateVariables = false;
    }

    public static void updatePosition(int p)
    {
        //Checks to see that you are going through the race in the correct direction
        if (p == position + 1)
        {
            position++;
            updateVariables = true;
        }
    }

    public static void updateLap()
    {
        //Checks to see if the player has gone through the track in the correct order before setting the lap
        if (position == maxPosition)
        {
            lap++;
            displayLap.updateLap();

            if (lap > maxLap)
            {
                Debug.Log("You Finished the Race!");
                SceneManager.LoadScene("WinScreen");
                lap = 1;
            }

            position = 0;
            updateVariables = true;
        }
    }

}
