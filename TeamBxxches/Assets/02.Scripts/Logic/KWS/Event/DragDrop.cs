using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private Canvas canvas = null;

    private RectTransform rectTransform;

    private CanvasGroup canvasGroup;

    private Vector3 initialPos;

    public virtual void Awake()
    {
        canvas = transform.root.GetComponent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        StartDrag();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
        EndDrag();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    #region Private

    private void StartDrag()
    {
        "드래그 시작 위치".LogError();
        initialPos = rectTransform.position;

    }

    private void EndDrag()
    {
        "드래그 종료 위치".LogError();
        rectTransform.position = initialPos;
    }

    #endregion
}
