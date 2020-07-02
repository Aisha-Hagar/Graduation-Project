using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyButton : MonoBehaviour
{
    Vector3 UpPos, DownPos;

    // Start is called before the first frame update
    void Start()
    {
        UpPos = new Vector3(transform.position.x, 1.3644f, transform.position.z);
        DownPos = new Vector3(transform.position.x, 1.343f, transform.position.z);
    }

    public void OnDown()
    {
        Debug.Log("Press");
        transform.position = DownPos;
    }

    public void OnUp()
    {
        Debug.Log("Release");
        transform.position = UpPos;
    }
}
