using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class modeSelection : MonoBehaviour
{
    [Header("Game Mode Selection Options:")]
    public string[] gameModes = new string[] { "freeplay", "beat the clock", "ghost computer", "live race against computer" };
    
    public static string gameModeSelected;
    public static int gameModeNumber;

    [Header("Time:")]
    public float timeTilStart;
    public int timeInSeconds;
    public Text textToDisplay;
    public bool adjustTimeObject;
    public GameObject startTimeGameObject;

    [Header("Player")]
    public GameObject car;
    public Rigidbody rb;

    [Header("CPU Car")]
    public GameObject ghostCPU;
    public Rigidbody ghostCPU_rb;

    void Awake()
    {
        startTimeGameObject = GameObject.FindGameObjectWithTag("initialCountDown");

        car = GameObject.FindGameObjectWithTag("Player");
        rb = car.GetComponent<Rigidbody>();
        rb.Sleep();

        setMode();
        adjustTimeObject = true;
    }

    void Update()
    {
        if (adjustTimeObject)
            startTime();
    }

    void setMode()
    {
        gameModeSelected = gameModes[gameModeNumber];

        switch (gameModeNumber)
        {
            case 0:
                startFreeplayMode();
                return;
            case 1:
                startBeatTheClockMode();
                return;

            case 2:
                startGhostComputerMode();
                return;

            case 3:
                startAIRaceMode();
                return;

        }
    }

    void startFreeplayMode()
    {
        Debug.Log("Freeplay mode selected!");

        setGameObjectsWithTagState(true, false, false, false);
    }

    void startBeatTheClockMode()
    {
        Debug.Log("Beat the clock mode selected!");
        timer.startCountDown = true;
        setGameObjectsWithTagState(false, true, false, false);
    }

    void startGhostComputerMode()
    {
        Debug.Log("Race against a ghost mode selected!");

        setGameObjectsWithTagState(false, false, true, false);

    }

    void startAIRaceMode()
    {
        Debug.Log("Race against a live computer selected!");

        setGameObjectsWithTagState(false, false, false, true);
    }

    void setGameObjectsWithTagState(bool isActive1, bool isActive2, bool isActive3, bool isActive4)
    {
        //Set GameObjects
        GameObject[] fp;
        fp = GameObject.FindGameObjectsWithTag("freeplay");
        GameObject[] clock;
        clock = GameObject.FindGameObjectsWithTag("raceAgainstClock");
        GameObject[] ghost;
        ghost = GameObject.FindGameObjectsWithTag("raceAgainstGhost");
        GameObject[] computer;
        computer = GameObject.FindGameObjectsWithTag("raceAgainstComputer");

        //Freeplay GameObjects
        foreach (GameObject obj in fp)
        {
            obj.SetActive(isActive1);
        }

        //Race Against the Clock GameObjects
        foreach (GameObject obj in clock)
        {
            obj.SetActive(isActive2);
        }

        //Race Against the Ghost GameObjets
        foreach (GameObject obj in ghost)
        {
            obj.SetActive(isActive3);
        }

        //Race Against the CPU GameObjects
        foreach (GameObject obj in computer)
        {
            obj.SetActive(isActive4);
        }
    }

    //Countdown to start the Game
    void startTime()
    {
        timeTilStart -= Time.deltaTime;
        timeInSeconds = (int)timeTilStart;

        if (timeInSeconds >= 4)
        {
            rb.Sleep();
            textToDisplay.text = "";

            if (gameModeSelected == "ghost computer")
                ghostCPU_rb.Sleep();
        }

        else if (timeInSeconds > 0)
        {
            textToDisplay.text = timeInSeconds.ToString();
            rb.Sleep();

            if (gameModeSelected == "ghost computer")
                ghostCPU_rb.Sleep();
        }

        else if (timeInSeconds == 0)
        {
            textToDisplay.text = "Go";
            rb.WakeUp();

            if (gameModeSelected == "ghost computer")
                ghostCPU_rb.WakeUp();
        }

        else if (timeInSeconds < 0)
        {
            textToDisplay.text = "";

            rb.WakeUp();

            adjustTimeObject = false;

            if (gameModeSelected == "ghost computer")
                ghostCPU_rb.WakeUp();
        }
    }
}