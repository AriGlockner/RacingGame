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
    
    void Start()
    {
        cpu = this.gameObject;
        rb = cpu.GetComponent<Rigidbody>();
        
        canGo = false;
    }

    // Update is called once per frame
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
    	//Realize it's offroad
    	timeStill = 0f;
    	Debug.Log("Reset CPU Position");
    	
    	//Reset off road position
    	GameObject marker = getLapMarker(ghostLapTracker.cpuPos);    	
    	
    	rb.velocity = new Vector3(0f, 0f, 0f);
    	transform.position = marker.transform.position;
    	cpu.transform.rotation = marker.transform.rotation;
    	
    }
    
    GameObject getLapMarker(int pos)
    {
        GameObject[] checkpoints;
        checkpoints = GameObject.FindGameObjectsWithTag("positionMarker");

        foreach (GameObject obj in checkpoints)
        {
            if (obj.GetComponent<lapMarker>().positionInLap == pos)
                return obj;
        }
        
        return GameObject.FindGameObjectWithTag("newLap");
    }
}
