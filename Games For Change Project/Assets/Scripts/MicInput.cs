using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MicInput : MonoBehaviour
{
    public int sampleWindow = 64;
    private AudioClip microphoneClip;

    // Start is called before the first frame update
    void Start()
    {
        MicrophoneToAudioClip();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MicrophoneToAudioClip()
    {
        //Get the first microphone in device list (default)
        string microphoneName = Microphone.devices[0];

        //actually takes in audio input; the 20 duration is just to put something there since this mic input will be on loop (as long as object is active)
        microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
    }

    public float GetLoudnessFromMicrophoneClip()
    {
        return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), microphoneClip);
    }

    public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
    {
        //this makes an array of each of small intervals in a specified audio clip (start at startPosition, end at clipPosition)
        int startPosition = clipPosition - sampleWindow;

        if (startPosition < 0) return 0;

        float[] clipData = new float[sampleWindow];
        clip.GetData(clipData, startPosition);

        //this gets the mean loudness based on the small audio clip intervals in the array we just made
        float totalLoudness = 0;

        for (int i = 0; i < sampleWindow; i++)
        {
            totalLoudness += Mathf.Abs(clipData[i]);
        }

        return totalLoudness / sampleWindow;
    }
}
