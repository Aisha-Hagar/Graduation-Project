using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepTrackGO : MonoBehaviour
{
    public GameObject LoseCnvsPre;
    GameObject LoseCnvs;

    void Update()
    {
        if (this.gameObject.activeSelf)
            this.gameObject.transform.parent = null;
        if(this.gameObject.transform.childCount == 0)
        {
            if (GameResult.Win == 0)
            {
                LoseCnvs = (GameObject)Instantiate(LoseCnvsPre, new Vector3(0f,0f,0f), Quaternion.Euler(0f, 0f, 0f));
            }
        }
    }
}
