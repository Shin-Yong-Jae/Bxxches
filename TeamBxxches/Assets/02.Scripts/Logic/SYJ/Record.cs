using UnityEngine;

public class Record : MonoBehaviour
{
    AudioSource aud;
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    public void PlaySnd()
    {
        aud.Play();
    }

    public void RecSnd()
    {
        aud.clip = Microphone.Start(Microphone.devices[0], false, 5, 44100);
    }
}