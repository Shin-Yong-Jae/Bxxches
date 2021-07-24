using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSoundManager : SingletonMonoBase<InGameSoundManager>
{
    private const int c_Character_Count = 6;

    private AudioSource sfx_Source;

    [SerializeField] AudioSource[] characterSource = new AudioSource[c_Character_Count];

    public float sound_volume = 0.5f;

    private void Awake()
    {
        sfx_Source = GetComponent<AudioSource>();
    }

    public void Play_Sound_OneShot(AudioClip clip)
    {
        if(sfx_Source != null)
        {
            sfx_Source.Stop();
            sfx_Source.clip = clip;
            sfx_Source.Play();
        }
    }

    public void Play_Sound_Loop(AudioClip clip)
    {
        if (sfx_Source != null)
        {
            sfx_Source.Stop();
            sfx_Source.clip = clip;
            sfx_Source.loop = true;
            sfx_Source.Play();
        }
    }

    public void Stop_Sound()
    {
        if(sfx_Source != null)
        {
            sfx_Source.Stop();
        }
    }

    public void Set_Sound_Volume(float volume)
    {
        if (volume >= 1) sound_volume = 1;
        else if (volume <= 0) sound_volume = 0;

        sound_volume = volume;

        sfx_Source.volume = sound_volume;
    }

    public void Set_Character_Source(AudioSource source, int index)
    {
        if(characterSource[index] != null)
        {
            characterSource[index].Stop();
        }

        characterSource[index] = source;
        characterSource[index].loop = true;

        characterSource[index].Play();
    }
}