using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondDoorOpen : MonoBehaviour
{
	// Start is called before the first frame update

	private Animator animator;
	public AudioSource doorSound;
	/*//#pragma strict
	 //GameObject PlayerObject;
	 string message = "I am an NPC.";
	 double displayTime;
	 bool displayMessage = false;
	 */
	void Start()
	{
		animator = GetComponent<Animator>();
	}
	public void LoadEscapeRoom()
	{
		Debug.Log("Load Escaperoom");
		SceneManager.LoadScene("EscapeRoomlvl1");
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			animator.SetTrigger("Open2");

			doorSound.Play();
		}
		/*displayTime -= Time.deltaTime;
		if (displayTime <= 0.0)
		{
			displayMessage = false;*/
		if (Input.GetKeyDown(KeyCode.O))
		{
		  LoadEscapeRoom();
		}
	}
}

	/*void OnTriggerStay(Collider other)
	{
		if (Input.GetKeyDown(KeyCode.I)) {
			displayMessage = true;
			displayTime = 3.0;
		}
	}

	void OnGUI()
	{
		if (displayMessage)
		{
			GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), message);
		}
	}*/








/*var playerObject : GameObject;
 var message : String = "I am an NPC.";
 var displayTime : float = 3;
 var displayMessage : boolean = false;
 
 function Update()
{
    displayTime -= Time.deltaTime;
    if (displayTime <= 0.0)
    {
        displayMessage = false;
    }
}

function OnTriggerStay(other : Collider)
{
    if (other.collider.gameObject == playerObject && Input.Get$$anonymous$$eyDown($$anonymous$$eyCode.E)) {
        displayMessage = true;
        displayTime = 3.0;
    }
}

function OnGUI()
{
    if (displayMessage)
    {
        GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), message);
    }*/
	   