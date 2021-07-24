using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_Tutorial : MonoBehaviour
{
    [Header("Animator")]
    public Animator anim;

    public GameObject popup_InGame;
    public GameObject popup_Inventory;

    private void Awake()
    {
        StartCoroutine(Awake_Coroutine());    
    }

    private void Init()
    {
        popup_InGame.transform.localScale = new Vector3(0, 0, 0);
        popup_Inventory.transform.localScale = new Vector3(0, 0, 0);
    }

    private IEnumerator Awake_Coroutine()
    {
        Init();
        while(true)
        {
            if(Input.anyKey)
            {
                AnimTrigger("tr_tutorial");
                yield break;
            }

            yield return null;
        }
    }

    public void Tutorial_First_Finished()
    {
        if(InGameManager.Instance.isTutorialEnd)
        {
            AnimTrigger("tr_tutorial_end");
        }
        else
        {
            AnimTrigger("tr_tutorial");

        }
    }

    public void Tutorial_Not_End_Finish()
    {
        InGameManager.Instance.isTutorialEnd = true;
        AnimTrigger("tr_tutorial_end");
    }

    public void Tutorial_End_Finish()
    {
        popup_InGame.transform.localScale = new Vector3(1, 1, 1);
        popup_Inventory.transform.localScale = new Vector3(1, 1, 1);
    }

    #region Private

    private void AnimTrigger(string str)
    {
        anim.SetTrigger(str);
    }

    #endregion

}