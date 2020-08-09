using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool gameIsPaused;

    void PauseGame()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

}
