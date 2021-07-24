using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour/*, IObserver*/
{
    [SerializeField] GameObject soundBar;
    [SerializeField] AudioSource audioSource;
    ButtonSubject subject;

    bool isClicked = false;
    float time = 0;

    //private void Start()
    //{
    //    subject = GameObject.Find("ButtonSubject").GetComponent<ButtonSubject>();
    //    subject.AddObserver(this);
    //}

    void Update()
    {
        audioSource.volume = soundBar.GetComponent<Slider>().value;

        if (isClicked)
        {
            time += Time.deltaTime;
            soundBar.SetActive(true);

            if (time >= 3)
            {
                soundBar.SetActive(false);
                isClicked = false;
                time = 0;
            }
        }
    }


    public void SoundBar()
    {
        isClicked = true;
        time = 0;
    }

    //public void Updated()
    //{

    //}
}
