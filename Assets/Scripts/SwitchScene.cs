using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
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
