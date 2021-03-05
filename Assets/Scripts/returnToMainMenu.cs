using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnToMainMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            switchScene("MainMenu");
    }

    void switchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
