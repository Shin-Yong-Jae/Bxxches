using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class EntireVolumeControl : MonoBehaviour
{
    [SerializeField] Slider EntireVolume_Slider;


    void Awake()
    {
        StartCoroutine(OnUpdateCoroutone());
    }

    private IEnumerator OnUpdateCoroutone()
    {
        while(true)
        {
            for (int i = 0; i < SoundManager.instanace.map_source.Count; i++)
            {
                SoundManager.instanace.map_source[i].volume = EntireVolume_Slider.value;
            }
            yield return null;
        }
    }
}
