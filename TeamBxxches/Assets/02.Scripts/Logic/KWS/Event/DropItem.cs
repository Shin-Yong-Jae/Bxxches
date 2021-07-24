using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropItem : MonoBehaviour, IDropHandler
{
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
            "Test".LogError();

            var obj = eventData.pointerDrag;
           index = obj.GetComponent<DragItem>().index;

            EnableComponent(true);
            SetAnimation(index);
            SetImage_Sprite(index);
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

    #endregion
}