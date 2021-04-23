using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class calculatePlace : MonoBehaviour
{
    
    [Header("Text")]
    public Text place;
    public int vehiclesAhead;

    [Header("Player")]
    public GameObject player;
    public int playerLap;
    public int playerPosition;
    public float playerDistanceToCheckpoint;

    [Header("CPU")]
    public GameObject[] CPU_Vehicles;
    public int cpuLap;
    public int cpuPos;
    public float cpuDistance;

    [Header("Lap Trackers")]
    public GameObject[] lapTrackers;
    public GameObject newLapMarker;

    [Header("Other")]
    public int frames;
    public int maxFrames;

    void Start()
    {
        CPU_Vehicles = GameObject.FindGameObjectsWithTag("ghost");
        player = GameObject.FindGameObjectWithTag("Player");

        lapTrackers = GameObject.FindGameObjectsWithTag("positionMarker");
    }

    
    void Update()
    {
        frames++;

        if (frames >= maxFrames)
        {
            setText(getPosition());
            frames = 0;
        }
    }

    int getPosition()
    {
        vehiclesAhead = 0;

        //Player position lap and position values
        playerLap = LapTracker.lap;
        playerPosition = LapTracker.position;

        //Next player Checkpoint distance
        GameObject lapMarker;
        lapMarker = getMarkerPosition(playerPosition);
        playerDistanceToCheckpoint = getDistanceApart(player.transform.position, lapMarker.transform.position);

        //Checks to see how many cpu vehicles are ahead of the player
        foreach (GameObject comp in CPU_Vehicles)
        {
            //Checks Lap
            cpuLap = comp.GetComponent<ghostLapTracker>().getLap();

            if (cpuLap > playerLap)
                vehiclesAhead++;

            else if (cpuLap == playerLap)
            {
                //Checks position
                cpuPos = comp.GetComponent<ghostLapTracker>().getPos();

                if (cpuPos > playerPosition)
                    vehiclesAhead++;

                else if (cpuPos == playerPosition)
                {
                    //Checks distance to next checkpoint
                    cpuDistance = getDistanceApart(comp.transform.position, getMarkerPosition(cpuPos).transform.position);

                    if (cpuDistance < playerDistanceToCheckpoint)
                        vehiclesAhead++;
                }
            }
        }
        return vehiclesAhead + 1;
    }

    GameObject getMarkerPosition(int markerNumber)
    {
        //Returns Game Object that the player is going to
        foreach (GameObject m in lapTrackers)
        {
            if (m.GetComponent<lapMarker>().positionInLap == markerNumber + 1)
                return m;
        }

        return newLapMarker;
    }

    float getDistanceApart(Vector3 obj1, Vector3 obj2)
    {
        float x = Mathf.Pow(obj1.x - obj2.x, 2);
        float y = Mathf.Pow(obj1.y - obj2.y, 2);
        float z = Mathf.Pow(obj1.z - obj2.z, 2);

        return Mathf.Sqrt(x + y + z);
    }

    void setText(int position)
    {
        switch (position)
        {
            case 1:
                place.text = "1st";
                return;
            case 2:
                place.text = "2nd";
                return;
            case 3:
                place.text = "3rd";
                return;
            case 4:
                place.text = "4th";
                return;
            case 5:
                place.text = "5th";
                return;
            case 6:
                place.text = "6th";
                return;
        }
        place.text = null;
    }
    
}
