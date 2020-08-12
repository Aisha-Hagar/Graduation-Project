﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherSpeech : MonoBehaviour
{
    public AudioSource teacherSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.P))
		{
            teacherSound.Play();
           
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            teacherSound.Stop();
        }

    }
}