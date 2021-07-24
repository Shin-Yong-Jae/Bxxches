using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropInfo : MonoBehaviour
{
    Image image;
    Button button;
    Animator anim;
    Slider slider_Sound;
    Canvas_InGame canvas_InGame;


    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        anim = GetComponent<Animator>();
        slider_Sound = transform.GetChild(0).GetComponent<Slider>();
        canvas_InGame = GameObject.Find("Popup_InGame").GetComponent<Canvas_InGame>();
        InitButton_OpenSound();
    }

    /// <summary>
    /// 컴포넌트 활성화 여부 판별
    /// </summary>
    /// <param name="value"></param>
    public void EnabledComponent(bool value)
    {
        anim.enabled = value;
    }

    public void SetAnimation(int index)
    {
        anim.runtimeAnimatorController = canvas_InGame.list_CharacterInfo[index].animator;
    }

    public void SetImage_Sprite(int index)
    {
        image.sprite = canvas_InGame.list_CharacterInfo[index].sprite;
        image.SetNativeSize();
    }

    #region Private

    private void InitButton_OpenSound()
    {
        button.onClick?.RemoveAllListeners();
        button.onClick?.AddListener(delegate 
        {
            OpenSound_Sliderbar();
        });
    }

    private void OpenSound_Sliderbar()
    {
        "Open SliderBar".LogError();
        slider_Sound.gameObject.SetActive(true);
    }

    #endregion
}