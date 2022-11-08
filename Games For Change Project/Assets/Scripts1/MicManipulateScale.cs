using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicManipulateScale : MonoBehaviour
{
    public AudioSource source;
    public Vector2 minScale;
    public Vector2 maxScale;
    public MicInput detector;

    public float volumeThreshold = 0.03f;
    public float sensitivity = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float loudness = detector.GetLoudnessFromAudioClip(source.timeSamples, source.clip); - this is for audio clips

        float loudness = detector.GetLoudnessFromMicrophoneClip()*sensitivity;

        if (loudness < volumeThreshold) loudness = 0;

        //lerp will confine the loudness value between chosen minScale and maxScale values
        transform.localScale = Vector2.Lerp(minScale, maxScale, loudness);
    }
}
