using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

public class HaloOnFocus : MonoBehaviour, IMixedRealityFocusHandler
{
    Behaviour halo;

    // Start is called before the first frame update
    void Start()
    {
        halo = (Behaviour)GetComponent("Halo");
        halo.enabled = false;
    }

    //Enable halo effect when pointer is focused on gameobject to show that the gameobject is grabbable
    public void OnFocusEnter(FocusEventData eventData)
    {
        halo.enabled = true;

    }

    //Disable halo effect when pointer is away from gameobject to show that the gameobject is not grabbable
    public void OnFocusExit(FocusEventData eventData)
    {
        halo.enabled = false;
    }
}
