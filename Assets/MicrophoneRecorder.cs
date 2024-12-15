using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MicrophoneRecorder : MonoBehaviour
{
    private AudioClip recordedClip;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private TextMeshProUGUI popUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If player presses 'm' key and is within sphere collider, record 2 seconds of audio, then play it back after one second
        if (Input.GetKeyDown(KeyCode.M))
        {
            StartRecording();
        }

        // If player presses 'p' key and is within sphere collider, play back the recorded audio
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayRecording();
        }
    }

    void StartRecording()
    {
        popUp.text = "Recording...";
        string device = Microphone.devices[0];
        int sampleRate = 44100;
        int length = 2;
        recordedClip = Microphone.Start(device, false, length, sampleRate);
        Invoke("StopRecording", length);
    }

    void StopRecording()
    {
        popUp.text = "";
        Microphone.End(null);
    }

    void PlayRecording()
    {
        audioSource.clip = recordedClip;
        audioSource.Play();
    }
}
