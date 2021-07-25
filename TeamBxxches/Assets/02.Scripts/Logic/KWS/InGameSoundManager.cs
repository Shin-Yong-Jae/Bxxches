using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSoundManager : SingletonMonoBase<InGameSoundManager>
{
    private const int c_Character_Count = 6;

    private AudioSource sfx_Source;
    //[SerializeField] List<AudioSource> characterSource = new List<AudioSource>();
    [SerializeField] AudioSource[] characterSource = new AudioSource[c_Character_Count];

    public float sound_volume = 0.5f;

    private void Awake()
    {
        sfx_Source = GetComponent<AudioSource>();
    }

    public void Play_Sound_OneShot(AudioClip clip)
    {
        if (sfx_Source != null)
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
        if (sfx_Source != null)
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
        if (characterSource[index] != null)
        {
            characterSource[index].Stop();
        }

        characterSource[index] = source;
        characterSource[index].loop = true;

        //StartCoroutine(CheckAudioTime(source, index));

        characterSource[index].Play();

        int enableCount = 0;

        for(int i = 0; i < characterSource.Length; i++)
        {
            if(characterSource[index] != null)
            {
                enableCount++;
            }
        }

        if(enableCount == c_Character_Count)
        {
            //버튼 활성화
            GameObject.Find("Canvas_InGame_UI").GetComponent<Canvas_InGameUI>().EnableButton();
        }
    }

    //IEnumerator CheckAudioTime(AudioSource source, int index)
    //{
    //    if (characterSource[index] != null)
    //    {
    //        characterSource[index].Stop();
    //    }

    //    characterSource[index] = source;
    //    //characterSource[index].loop = true;

    //    while (true)
    //    {
    //        int allCount = 0;
    //        int count = 0;

    //        for (int i = 0; i < c_Character_Count; i++)
    //        {
    //            if (characterSource[i].clip != null)
    //            {
    //                allCount++;

    //                if (!characterSource[i].isPlaying)
    //                {
    //                    count++;
    //                    yield return null;
    //                }
    //            }
    //        }

    //        if (count == allCount)
    //        {
    //            for (int i = 0; i < c_Character_Count; i++)
    //            {
    //                characterSource[i].loop = true;
    //                //yield return new WaitForSeconds(0.1f);
    //                characterSource[i].loop = false;
    //                characterSource[i].Play();
    //                yield return null;
    //                //yield break;
    //            }
    //            print("실행");
    //        }
    //        yield return null;
    //    }
    //}

    //private void Update()
    //{
    //    print(characterSource[0].time);
    //}
}