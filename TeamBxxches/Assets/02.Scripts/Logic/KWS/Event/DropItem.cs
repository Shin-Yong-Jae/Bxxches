using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour, IDropHandler
{
    RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            $"Get".LogError();
            GameObject obj = eventData.pointerDrag;
            RectTransform rt = ((RectTransform)obj.transform);
            DragItem dragItem = obj.GetComponent<DragItem>();
            Destroy(dragItem);

            ((RectTransform)obj.transform).SetParent(rectTransform);
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }
}