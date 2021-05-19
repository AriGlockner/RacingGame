using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetCPUposition : MonoBehaviour
{
    [Header("Other GameObjects")]
    public GameObject cpu;
    public Rigidbody rb;
    [Space]
    public bool canGo;
     
    [Header("Reset Info")]
    public float speed;
    public float speedToReset;
    [Space]
    public float resetTime;
    public float timeStill;

    [Header("Waypoints:")]
    public GameObject[] waypoints;
    public GameObject newLapWaypoint;

    [Header("Current Waypoint info")]
    public int currentWaypointNumber;
    public Vector3 positionOfWaypoint;
    public Vector3 rotationOfWaypoint;

    void Start()
    {
        //Vechicle Stuff
        cpu = this.gameObject;
        rb = cpu.GetComponent<Rigidbody>();
        canGo = false;

        //Waypoints
        waypoints = GameObject.FindGameObjectsWithTag("cpuWaypointCheckpoints");
        newLapWaypoint = GameObject.FindGameObjectWithTag("newLap");

        //Set current waypoint
        currentWaypointNumber = 0;
        positionOfWaypoint = newLapWaypoint.GetComponent<newLap>().position;
        rotationOfWaypoint = newLapWaypoint.GetComponent<newLap>().rotation;

        //Set waypoint numbers
        int num = 1;
        foreach (GameObject w in waypoints)
        {
            w.GetComponent<waypointInfo>().waypointNumber = num;
            num++;
        }
    }

    void Update()
    {

        speed = rb.velocity.magnitude;
        
        if (canGo)
        {
        	if (speed <= speedToReset)
        	{
        		timeStill += Time.deltaTime;
        		
        		if (timeStill >= resetTime)
        			resetPosition();
        	}
        	else
        		timeStill = 0f;
    	}
    	
    	else
    		canGo = modeSelection.canGo;

    }
    
    void resetPosition()
    {
    	timeStill = 0f;
    	Debug.Log("Reset CPU Position");

        //Reset the vehicle
    	rb.velocity = new Vector3(0f, 0f, 0f);
        transform.position = positionOfWaypoint;
        transform.eulerAngles = rotationOfWaypoint;
    }

    public void updateWaypoint(int newWaypointNumber, Vector3 position, Vector3 rotation)
    {
        if (newWaypointNumber == 0)
        {
            currentWaypointNumber = 0;
            positionOfWaypoint = newLapWaypoint.GetComponent<newLap>().position;
            rotationOfWaypoint = newLapWaypoint.GetComponent<newLap>().rotation;
            return;
        }

        currentWaypointNumber = newWaypointNumber;
        positionOfWaypoint = position;
        rotationOfWaypoint = rotation;
    }
}
