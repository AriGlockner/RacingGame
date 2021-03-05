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
            switchScene("Track-1");
    }

    void switchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
