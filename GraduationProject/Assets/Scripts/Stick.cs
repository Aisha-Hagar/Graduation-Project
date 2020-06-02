using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public GameObject Key, Canvas;
    Animator BoxOpen;
    //Vector3 pos = new Vector3(0.0f,0.0f,-0.5f);
    public Vector3 pos;

    void Start()
    {
        Debug.Log("Start Box");
        BoxOpen = gameObject.GetComponent<Animator>();

    }

    void Update()
    {
        Canvas.transform.position = transform.TransformPoint(pos);
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.name=="Scale")
        {
            this.transform.parent = collision.gameObject.transform;
            Debug.Log("Stick");
        }

    }

    void OnCollisionExit(Collision collision)
    {
        
        if (collision.gameObject.name == "Scale")
        {
            this.transform.parent = null;
            Debug.Log("Unstick");
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Trigger");
        if (collider.gameObject == Key)
        {
            Debug.Log("Click");
            BoxOpen.SetTrigger("Open");
            Debug.Log("Open Box");
            Debug.Log("KeyInLock");
            
            if (Canvas != null)
            {
                GameObject cnvs = Canvas.transform.GetChild(0).gameObject;
                StartCoroutine(Wait(cnvs));
                Debug.Log("Opened " + gameObject.name);
            }
            else
            {
                Debug.Log("Not found");
            }
        }
    }

    IEnumerator Wait(GameObject cnvs)
    {
        yield return new WaitForSecondsRealtime(1.5f);
        cnvs.SetActive(true);
    }
}
