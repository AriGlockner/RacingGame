using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keySelectScene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
            switchScene("TestingScene");

        
        if (Input.GetKey(KeyCode.Alpha2))
            startLevel("Track-1", 0);

        
        if (Input.GetKey(KeyCode.Alpha3))
            startLevel("Track-1", 1);

        if (Input.GetKey(KeyCode.Alpha4))
            startLevel("Track-1", 2);

        if (Input.GetKey(KeyCode.Alpha5))
            startLevel("Track-1", 3);
        
    }

    void switchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void startLevel(string sceneName, int num)
    {
        modeSelection.gameModeNumber = num;

        SceneManager.LoadScene(sceneName);
    }
}
