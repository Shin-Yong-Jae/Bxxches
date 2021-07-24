using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EditControl : MonoBehaviour
{
    [SerializeField ]Button EditButton;
    [SerializeField] GameObject EditPage;
    [SerializeField] Button CloseEditButton;
    [SerializeField] Button GoMainButton;

    public void OnClickEditButton()
    {
        EditPage.SetActive(true);
    }

    public void OnClickCloseEditButton()
    {
        EditPage.SetActive(false);
    }

    public void GoMain()
    {
        SceneManager.LoadScene("MainScene");
    }
}
