using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SoundManager : MonoBehaviour
{
    static public SoundManager instanace;
    #region singleton
    void Awake()
    {
        if (instanace == null)
        {
            instanace = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    #endregion
    public List<AudioSource> map_source = new List<AudioSource>();
    public AudioSource baseAudioSource;

    public void Add_Source(AudioSource source)
    {
        if (map_source.Count < Config.c_Max_Character_Size)
        {
            map_source.Add(source);
        }
    }

    public void Remove_Source(AudioSource source)
    {
        if (map_source.Count > 0)
        {
            if (map_source.Contains(source))
            {
                map_source.Remove(source);
            }
        }
    }

    public void PlaySound() // AudioSource List 실행.
    {
        for (int i = 0; i < map_source.Count; i++)
        {
            map_source[i].Play();
        }
    }

    public void StopAllSound() //리스트에서 빼 버리는게 맞나?
    {
        for (int i = 0; i < map_source.Count; i++)
        {
            //map_source[i].Stop();
            Remove_Source(map_source[i]);
        }
    }
}

