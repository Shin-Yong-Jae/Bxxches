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
        if(map_source.Count < Config.c_Max_Character_Size)
        {
            map_source.Add(source);
        }
    }

    public void Remove_Source(AudioSource source)
    {
        if(map_source.Count > 0)
        {
            if(map_source.Contains(source))
            {
                //
            }
        }
    }


    //public void PlaySound(string _name) // 곡 실행.
    //{
    //    for (int i = 0; i < Sounds.Length; i++) // 들어온 클립 수 만큼 실행.
    //    {
    //        if(_name == Sounds[i].name)
    //        {
    //            for (int j = 0; j < audioSource.Length; j++)// audiosource가 재생중이지 않다면.
    //            {
    //                if(!audioSource[j].isPlaying)
    //                {
    //                    audioSource[j].clip = Sounds[i].clip;
    //                    audioSource[j].Play();
    //                    return;
    //                }
    //            }
    //            Debug.Log("AudioSource 모두 사용중");
    //            return;
    //        }
    //    }
    //    Debug.Log(_name + "등록되지 않은 Sound");
    //}

    //public void StopAllSound() // 모두 재생 멈춤.
    //{
    //    for (int i = 0; i < Sounds.Length; i++)
    //    {
    //        audioSource[i].Stop();
    //    }
    //}


    //private void Start()
    //{
    //    audioSource = GetComponent<AudioSource>();
    //}


    private void Update()
    {
        //임시 씬전환
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("Ex_Scene");
        }
    }
}

