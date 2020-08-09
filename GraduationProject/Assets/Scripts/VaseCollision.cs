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
    Behaviour halo;

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
        halo = (Behaviour)GetComponent("Halo");
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
                Debug.Log("Break Vase and show key");
                //Break the vase and play the sound effect
                CeramicBreak.Play();
                VaseMesh.enabled = false;
                BrokenVase = (GameObject)Instantiate(BrokenVasePre, BrokenVasePos, Quaternion.Euler(-90f, 90f, 0f));
                //Create key
                Key = (GameObject)Instantiate(KeyPre, new Vector3(-2.487f, 1.501f, -0.556f), Quaternion.Euler(105f, -27f, 50f));
                //BrokenVase.name = "BrokenVase";
                Key.name = "KeyMain";
                Key.tag = "KeyMain";
            }
            else if (BreakValue < Value)
            {

                Debug.Log("Break Vase and Key");
                //Break the vase and key and play the sound effect
                VaseMesh.enabled = false;
                CeramicBreak.Play();
                BrokenVase = (GameObject)Instantiate(BrokenVasePre, BrokenVasePos, Quaternion.Euler(-90f, 90f, 0f));
                BrokenKey = (GameObject)Instantiate(BrokenKeyPre, new Vector3(-2.482f, 1.481f, -0.5952f), Quaternion.Euler(0f, 0f, 0f));
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
            this.GetComponent<HaloOnFocus>().enabled = false;
            halo.enabled = false;
            this.transform.position = VDropZoneCollider.gameObject.transform.position;
            Debug.Log("Attach Vase to plane");
        }
    }

    IEnumerator DestroyVase()
    {
        yield return new WaitForSeconds(2);
        if (BrokenVase != null)
            Destroy(BrokenVase);
        /*
        if (BrokenKey != null)
        {
            yield return new WaitForSeconds(2);
            Destroy(BrokenKey);
        }
        */
        Destroy(this.gameObject);
    }
}
