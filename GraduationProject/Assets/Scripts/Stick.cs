using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
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
}
