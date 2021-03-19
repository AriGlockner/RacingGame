using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetOffRoadPosition : MonoBehaviour
{
    [Header("Variables for determining if it's off road")]
    public float timeAllowedOffRoad;
    public float timeSinceOnTrack;
    public bool offTrack;

    [Header("Reset the Car's position")]
    public Vector3 positionOfMarker;
    public float rotationOfMarker;
    public GameObject car;
    public Rigidbody rb;

    [Header("Sleeping")]
    public bool isSleeping;
    public float sleepDuration;
    public float sleepTime;

    void Start()
    {
        timeSinceOnTrack = 0f;

        car = GameObject.FindGameObjectWithTag("Player");
        rb = car.GetComponent<Rigidbody>();
    }

    void Update()
    {

        //Check if the car is off of the road
        if (offTrack)
        {
            timeSinceOnTrack += Time.deltaTime;

            if (timeSinceOnTrack >= timeAllowedOffRoad)
            {
                Debug.Log("Reset Car Position");
                resetCarPosition();
            }
        }

        if (isSleeping)
            sleepCar();
    }

    //Determine if the car is off road or not

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "terrain")
            offTrack = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "terrain")
        {
            offTrack = false;
            timeSinceOnTrack = 0f;
        }
    }

    //Reset the car position

    public GameObject FindPreviousLapMarkerObject()
    {
        GameObject[] checkpoints;
        checkpoints = GameObject.FindGameObjectsWithTag("positionMarker");

        foreach (GameObject obj in checkpoints)
        {
            if (obj.GetComponent<lapMarker>().positionInLap == LapTracker.position)
                return obj;
        }
        
        return checkpoints[0];
    }

    void resetCarPosition()
    {
        //Get Position to teleport to
        GameObject checkpoint = FindPreviousLapMarkerObject();
        positionOfMarker = checkpoint.transform.position;
        rotationOfMarker = checkpoint.transform.rotation.y;

        //Set the car's position and rotation
        car.transform.position = positionOfMarker;
        car.transform.rotation = checkpoint.transform.rotation;

        //Set the car's velocity equal to 0
        rb.velocity = new Vector3(0f, 0f, 0f);

        isSleeping = true;
        rb.Sleep();
        Debug.Log("Sleep");
    }

    void sleepCar()
    {
        //Significantly reduces player movement
        sleepDuration += Time.deltaTime;
        rb.Sleep();
        rb.velocity = new Vector3(0f, 0f, 0f);

        //Checks to see that the player should still be paused
        if (sleepDuration >= sleepTime)
        {
            isSleeping = false;

            rb.WakeUp();
            Debug.Log("Wake Up");

            sleepDuration = 0f;
        }
    }
}
