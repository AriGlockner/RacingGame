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

    //
    
    //

    void Start()
    {
        cpu = this.gameObject;
        rb = cpu.GetComponent<Rigidbody>();
        
        canGo = false;
        waypoints = GameObject.FindGameObjectsWithTag("cpuWaypointCheckpoints");
        newLapWaypoint = GameObject.FindGameObjectWithTag("newLap");

        setWaypointNumbers();
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

        //Get location to go to
        GameObject goTo = getWaypoint();

        //Reset the vehicle
    	rb.velocity = new Vector3(0f, 0f, 0f);
    	transform.position = goTo.transform.position;
    	cpu.transform.rotation = goTo.transform.rotation;
    }

    GameObject getWaypoint()
    {
        //Find the previous checkpoint

        //Defualt set to the start of the track
        return newLapWaypoint;
    }

    void setWaypointNumbers()
    {
        int i = 0;

        foreach (GameObject obj in waypoints)
        {
            obj.GetComponent<waypointInfo>().waypointNumber = i;
            i++;
        }
    }
}
