using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_InGameUI : MonoBehaviour
{
    public GameObject ending;

    public Button button_Ending;

    public void OnClick_Button_Ending()
    {
        ending.SetActive(true);
    }

    public void EnableButton()
    {
        button_Ending.gameObject.SetActive(true);
    }
}