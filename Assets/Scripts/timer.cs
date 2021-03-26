using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public float raceTime;
    public int timeInSeconds;
    public Text textToDisplay;
    public static bool startCountDown;

    void Start()
    {
        startCountDown = false;
    }

    void Update()
    {
        if (startCountDown)
        {


            raceTime -= Time.deltaTime;
            timeInSeconds = (int)raceTime;

            if (timeInSeconds < 0f)
                SceneManager.LoadScene("LoseScreen");

            textToDisplay.text = timeInSeconds.ToString();
        }
        else
        {
            textToDisplay.text = "";
        }
    }
}
