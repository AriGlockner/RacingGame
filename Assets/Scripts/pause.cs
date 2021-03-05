using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public bool isPaused;
    private GameObject otherObject;

    void Start()
    {
        isPaused = false;
        otherObject = GameObject.FindWithTag("Pause");

        otherObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            togglePaused();
    }

    void togglePaused()
    {
        isPaused = !isPaused;
        otherObject.SetActive(isPaused);
        AudioListener.pause = isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
