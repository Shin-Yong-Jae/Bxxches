using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public AudioClip audioClip;

    private Canvas canvas = null;

    private RectTransform rectTransform;

    private CanvasGroup canvasGroup;

    private Vector3 initialPos;

    public AudioSource audioSource;

    public Canvas_Inventory canvas_Inventory;

    public EItemType eItemType;

    //Parent
    private RectTransform parent;

    //드래그 중일 때의 RectTransform
    private RectTransform draggingTransform;

    public int index;

    public virtual void Awake()
    {
        canvas_Inventory = GameObject.Find("Popup_Inventory").GetComponent<Canvas_Inventory>();
        canvas = transform.root.GetComponent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        draggingTransform = (RectTransform)rectTransform.root.transform;
        parent = (RectTransform)rectTransform.parent;
        audioSource = GetComponent<AudioSource>();
        audioClip = canvas_Inventory.list_inventoryData[index].audioClip;
        audioSource.clip = audioClip;

        SetItemType(EItemType.Before_Drag);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        InGameSoundManager.Instance.Stop_Sound();
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        SavePriorPosition();

        //부모 조정
        SetDraggingTransform();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
        ResetPosition();

        SetNotDraggingTransform();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void SetItemType(EItemType eType)
    {
        eItemType = eType;
    }

    #region Private

    private void SavePriorPosition()
    {
        "드래그 시작 위치".LogError();
        initialPos = rectTransform.position;

    }

    private void ResetPosition()
    {
        "드래그 종료 위치".LogError();
        rectTransform.position = initialPos;
    }

    private void SetDraggingTransform()
    {
        transform.SetParent(draggingTransform);
        transform.SetAsLastSibling();
    }

    private void SetNotDraggingTransform()
    {
        transform.SetParent(parent);
        transform.SetSiblingIndex(index);
    }

    #endregion
}
