using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropItem : MonoBehaviour, IDropHandler
{
    [Header("DropItem Index")]
    public int dropItemIndex;

    private Image image;
    private DropInfo dropInfo;
    public int index { get; private set; } = -1;

    private void Awake()
    {
        Init();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            var obj = eventData.pointerDrag;
            var dragItem = obj.GetComponent<DragItem>();
            var dragDrop = obj.GetComponent<DragDrop>();
            index = dragDrop.index;

            EnableComponent(true);
            SetAnimation(index);
            SetImage_Sprite(index);

            dragItem.GetAudioClip().name.LogError();
            SetAudioClip(dragItem.GetAudioClip());
        }
    }

    #region Private

    private void Init()
    {
        InitComponent();
        InitData();
    }

    private void InitComponent()
    {
        image = GetComponent<Image>();
        dropInfo = GetComponent<DropInfo>();
        dropInfo.enabled = false;
    }

    private void InitData()
    {
        EnableComponent(false);
    }

    private void EnableComponent(bool value)
    {
        dropInfo.EnabledComponent(value);
    }

    private void SetAnimation(int index)
    {
        dropInfo.SetAnimation(index);
    }

    private void SetImage_Sprite(int index)
    {
        "[Set Sprite]".LogError();
        dropInfo.SetImage_Sprite(index);
    }

    private void SetAudioClip(AudioClip clip)
    {
        dropInfo.SetAudioClip(clip, index);
    }

    #endregion
}