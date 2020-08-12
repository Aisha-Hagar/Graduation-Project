using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideo : MonoBehaviour
{
    public UnityEngine.Video.VideoClip videoClip;
    // Start is called before the first frame update
    void Start()
    {
        var videoPlayer = gameObject.AddComponent<UnityEngine.Video.VideoPlayer>();
        var audioSource = gameObject.AddComponent<AudioSource>();

        videoPlayer.playOnAwake = false;
        videoPlayer.clip = videoClip;
        //videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.MaterialOverride;
        //videoPlayer.targetMaterialRenderer = GetComponent<Renderer>();
        //videoPlayer.targetMaterialProperty = "_MainTex";
        videoPlayer.audioOutputMode = UnityEngine.Video.VideoAudioOutputMode.AudioSource;
        videoPlayer.SetTargetAudioSource(0, audioSource);
    }

    // Update is called once per frame
    void Update()
    {
       var vp = GetComponent<UnityEngine.Video.VideoPlayer>();
       if (Input.GetKeyDown(KeyCode.P))
        {
            //vp = GetComponent<UnityEngine.Video.VideoPlayer>();

           /* if (vp.isPlaying)
            {
                vp.Pause();
            }
            else
            {*/
                vp.Play();

            //}
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (vp.isPlaying)
            {
                vp.Stop();
            }
        }
       }
}