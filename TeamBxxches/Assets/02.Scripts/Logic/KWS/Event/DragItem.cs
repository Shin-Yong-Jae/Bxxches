using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragItem : DragDrop
{

    public override void Awake()
    {
        base.Awake();
    }

    public int GetIndex()
    {
        $"Index :  : {index}".LogError();
        return index;
    }

    public AudioClip GetAudioClip()
    {
        return canvas_Inventory.list_inventoryData[index].audioClip;
    }

    #region Private


    #endregion
}
