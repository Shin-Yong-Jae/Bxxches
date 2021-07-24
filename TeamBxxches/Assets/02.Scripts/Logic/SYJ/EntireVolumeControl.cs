using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class EntireVolumeControl : MonoBehaviour
{
    [SerializeField] AudioSource[] SoundSource;

    [SerializeField] Slider EntireVolume_Slider;

    void Awake()
    {
        //SoundSource 할당.
        //for (int i = 0; i < SoundSource.Length; i++)
        //{
        //    SoundSource[i] = SoundManager.instanace.audioSource[i];
        //}
        //EntireVolume_Slider.value = SoundManager.instanace.audioSource[0].volume;

        StartCoroutine(OnUpdateCoroutone());
    }

    private IEnumerator OnUpdateCoroutone()
    {
        while(true)
        {
            for (int i = 0; i < SoundSource.Length; i++)
            {
                SoundSource[i].volume = EntireVolume_Slider.value;
            }
            yield return null;
        }
    }
}
