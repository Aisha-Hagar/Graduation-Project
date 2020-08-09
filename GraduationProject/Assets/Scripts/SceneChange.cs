using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void LoadEscapeRoom()
    {
        Debug.Log("Load Escaperoom");
        SceneManager.LoadScene("EscapeRoomlvl1");
    }

    public void LoadClassroom()
    {
        Debug.Log("Load Classroom");
        SceneManager.LoadScene("Classroomlvl1");
    }

    public void QuitGame()
    {
        Debug.Log("Exit Game");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
