using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockBox : MonoBehaviour
{
    public GameObject Box;
    Transform Tparent;
    GameObject parent;

    void Start()
    {
        Debug.Log("Start key");
        Tparent = this.transform.parent;
        parent = Tparent.gameObject;

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == Box)
        {
            Debug.Log("Open Box");
            Destroy(this.parent);
            Debug.Log("KeyInLock");
        }
    }
}
