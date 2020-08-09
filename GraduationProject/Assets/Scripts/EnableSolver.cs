using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSolver : MonoBehaviour
{
    Behaviour halo;
    bool OnTable = true;
    SolverHandler solverHandler;
    RadialView radialView;
    AudioSource PaperMove;
    public Vector3 PaperPos;
    public Quaternion PaperRot;
    //Vector3 PaperPos = new Vector3(3.355f, 1.445f, -0.749f);
    //Quaternion PaperRot = Quaternion.Euler(90f, 90f, 0f);

    void Start()
    {
        transform.position = PaperPos;
        transform.rotation = PaperRot;
        halo = (Behaviour)GetComponent("Halo");
        halo.enabled = true;
        solverHandler = GetComponent<SolverHandler>();
        solverHandler.enabled = false;
        radialView = GetComponent<RadialView>();
        radialView.enabled = false;
        PaperMove = GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        PaperMove.Play();
        if (OnTable)
        {
            halo.enabled = false;
            solverHandler.enabled = true;
            radialView.enabled = true;
            OnTable = false;
            Debug.Log("Clicked");
        }
        else
        {
            transform.position = PaperPos;
            transform.rotation = PaperRot;
            halo.enabled = true;
            solverHandler.enabled = false;
            radialView.enabled = false;
            OnTable = true;
            Debug.Log("UnClicked");
        }
    }
}
