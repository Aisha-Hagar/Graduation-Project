using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseCollision : MonoBehaviour
{
    public AudioSource CeramicBreak, CeramicScrap;
    public GameObject BrokenVasePre, KeyPre, BrokenKeyPre;
    GameObject BrokenVase = null, Key = null, BrokenKey = null;
    float BreakValue;
    public static float Value;
    private Collider VaseCollider;
    public Collider VDropZoneCollider;
    Vector3 BrokenVasePos = new Vector3(-1.813f, 1.131f, -1.136f);
    MeshRenderer VaseMesh;

    // Start is called before the first frame update
    void Start()
    {
        VaseCollider = GetComponent<Collider>();
        VaseCollider.isTrigger = true;
        VDropZoneCollider.isTrigger = true;
        this.gameObject.SetActive(true);
        VaseMesh = GetComponent<MeshRenderer>();
        //Set random value at which the vase will break
        BreakValue = SetBreakValue.GetVaseBreakValue();
        Debug.Log("MyBreakValue = " + BreakValue);
    }

    //On collision with hammer 
    void OnTriggerEnter(Collider collider)
    {

        Debug.Log("Enter Vase trigger by " + collider.gameObject.name);
        //Check if slider value is equal to BreakValue If equal, break the vase 
        if (collider.gameObject.name == "Hammer")
        {
            Debug.Log("Value = " + Value);
            if (BreakValue == Value)
            {
                Debug.Log("Break");
                //Break the vase and play the sound effect
                CeramicBreak.Play();
                VaseMesh.enabled = false;
                BrokenVase = (GameObject)Instantiate(BrokenVasePre, BrokenVasePos, Quaternion.Euler(-90f, 90f, 0f));
                //Create key
                Key = (GameObject)Instantiate(KeyPre, new Vector3(4e-10f, 0.015f, 0.88f), Quaternion.Euler(116f, 90f, 55f));
                BrokenVase.name = "BrokenVase";
                Key.tag = "KeyMain";
            }
            else if (BreakValue < Value)
            {

                Debug.Log("Break Vase and Key");
                //Break the vase and key and play the sound effect
                VaseMesh.enabled = false;
                CeramicBreak.Play();
                BrokenVase = (GameObject)Instantiate(BrokenVasePre, BrokenVasePos, Quaternion.Euler(-96.674f, 90f, -90f));
                BrokenKey = (GameObject)Instantiate(BrokenKeyPre, new Vector3(0.0226f, 0.1688f, 0.9277f), Quaternion.Euler(115.75f, 90f, 55.379f));
                BrokenVase.name = "BrokenVase";
                BrokenKey.name = "BrokenKey";
            }
            else
            {
                CeramicScrap.Play();
                this.transform.rotation = Quaternion.Euler(-180f, 90f, -90f);

            }
            StartCoroutine(DestroyVase());

        }
        else if (collider == VDropZoneCollider)
        {
            Debug.Log("Vase Collided with plane");
            this.GetComponent<NearInteractionGrabbable>().enabled = false;
            this.GetComponent<ManipulationHandler>().enabled = false;
            this.transform.position = VDropZoneCollider.gameObject.transform.position;
            Debug.Log("Attach Vase to plane");
        }
    }

    IEnumerator DestroyVase()
    {
        yield return new WaitForSeconds(2);
        if (BrokenVase != null)
            Destroy(BrokenVase);
        if (BrokenKey != null)
        {
            yield return new WaitForSeconds(2);
            Destroy(BrokenKey);
        }
        Destroy(this.gameObject);
    }
}
