using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class calculatePlace : MonoBehaviour
{
    
    [Header("Text")]
    public Text place;

    [Header("Player")]
    public GameObject player;
    public int playerLap;
    public int playerPosition;
    public float playerDistanceToCheckpoint;

    [Header("CPU")]
    public GameObject CPU_Vehicle;
    public int cpuLap;
    public int cpuPos;
    public float cpuDistanceToCheckpoint;

    [Header("Lap Trackers")]
    public GameObject[] lapTrackers;
    public GameObject newLapMarker;

    [Header("Other")]
    public string mode;
    private int frames;
    public int maxFrames;

    void Start()
    {
        CPU_Vehicle = GameObject.FindGameObjectWithTag(mode);
        player = GameObject.FindGameObjectWithTag("Player");

        lapTrackers = GameObject.FindGameObjectsWithTag("positionMarker");
    }

    
    void Update()
    {
        frames++;

        if (frames >= maxFrames)
        {
            setPosition();
            frames = 0;
        }
    }

    int setPosition()
    {
        //Player position lap and position values
        playerLap = LapTracker.lap;
        playerPosition = LapTracker.position;

        //CPU position lap and position values
        cpuLap = CPU_Vehicle.GetComponent<ghostLapTracker>().getLap();
        cpuPos = CPU_Vehicle.GetComponent<ghostLapTracker>().getPos();

        //Next player Checkpoint distance
        GameObject lapMarker;
        lapMarker = getMarkerPosition(playerPosition);
        playerDistanceToCheckpoint = getDistanceApart(player.transform.position, lapMarker.transform.position);


        //Next CPU Checkpoint distance
        lapMarker = getMarkerPosition(cpuPos);
        cpuDistanceToCheckpoint = getDistanceApart(CPU_Vehicle.transform.position, lapMarker.transform.position);

        //Compares Lap
        if (playerLap > cpuLap)
        {
            place.text = "1st";
            return 1;
        }
        if (playerLap < cpuLap)
        {
            place.text = "2nd";
            return 2;
        }

        //Compares Position
        if (playerPosition > cpuPos)
        {
            place.text = "1st";
            return 1;
        }
        if (playerPosition < cpuPos)
        {
            place.text = "2nd";
            return 2;
        }

        //Compares Position
        if (playerDistanceToCheckpoint < cpuDistanceToCheckpoint)
        {
            place.text = "1st";
            return 1;
        }
        
        place.text = "2nd";
        return 2;
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
}
