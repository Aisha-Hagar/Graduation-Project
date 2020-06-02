using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphrCldrRds : MonoBehaviour
{
    //This declares SphereCollider
    SphereCollider myCollider;

    // Start is called before the first frame update
    void Start()
    {
        //Assigns the attached SphereCollider to myCollider
        myCollider = GetComponent<SphereCollider>();
        myCollider.center = new Vector3(0.0f, 2.5f, 0.0f); ;
        //This sets the Collider radius 
        myCollider.radius = 4f;
        //If this is the correct key, enable trigger to open box
        if (tag == "Key")
        {
            myCollider.isTrigger = true;
        }
        else
        {
            myCollider.isTrigger = false;
        }
    }
}
