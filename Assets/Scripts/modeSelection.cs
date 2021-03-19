using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modeSelection : MonoBehaviour
{
    [Header("Game Mode Selection Options:")]
    public string[] gameModes = new string[] { "freeplay", "beat the clock", "ghost computer", "live race against computer" };
    
    public string gameModeSelected;
    public static int gameModeNumber;

    void Awake()
    {
        setMode();
    }

    void Start()
    {
        //gameModes = new string[] { "freeplay", "beat the clock", "Ghost Computer", "Live Race Computer" };
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
    }

    void startBeatTheClockMode()
    {
        Debug.Log("Beat the clock mode selected!");
    }

    void startGhostComputerMode()
    {
        Debug.Log("Race against a ghost mode selected!");
    }

    void startAIRaceMode()
    {
        Debug.Log("Race against a live computer selected!");
    }
}