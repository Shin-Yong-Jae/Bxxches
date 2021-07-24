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
    [SerializeField] Slider slider;

    private void Awake()
    {
        StartCoroutine(UpdateCoroutine());
    }

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
        SceneManager.LoadScene("MainScene2");
    }

    #region Private

    private IEnumerator UpdateCoroutine()
    {
        var soundManager = InGameSoundManager.Instance;

        while (!InGameManager.Instance.isGameCleared)
        {
            soundManager.Set_Sound_Volume(slider.value);

            yield return null;
        }
    }

    #endregion
}
