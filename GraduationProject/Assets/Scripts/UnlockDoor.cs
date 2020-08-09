using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockDoor : MonoBehaviour
{
    AudioSource Unlock;

    void Start()
    {
        Unlock = GetComponent<AudioSource>();
        GameResult.Win = 2; //Wait
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "KeyMain")
        {
            Debug.Log("Open Door");
            //play audio
            Unlock.Play();
            //destroy key
            collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
             collider.gameObject.GetComponent<HaloOnFocus>().enabled = false;
            GameResult.Win = 1;
            //go to next scene -> win
            Debug.Log("Load Win");
            StartCoroutine(GotoWin());
        }
    }

    IEnumerator GotoWin()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        SceneManager.LoadScene("Win");
    }
}
