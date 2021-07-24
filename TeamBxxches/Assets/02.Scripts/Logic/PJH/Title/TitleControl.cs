using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleControl : MonoBehaviour
{
    [SerializeField] float moveTime;
    [SerializeField] GameObject stopingStuff;
    [SerializeField] GameObject closeBg;

    float time;
    bool isDragOver = false;

    private void Start()
    {
        closeBg.SetActive(false);
    }

    IEnumerator DragBG()
    {
        float a = stopingStuff.transform.localPosition.y;

        while (stopingStuff.transform.localPosition.y <= a + 640)
        {
            stopingStuff.transform.localPosition += new Vector3(0, Time.deltaTime * moveTime, 0);
            yield return null;
        }

        isDragOver = true;
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            StartCoroutine(DragBG());
        }

        if (isDragOver)
        {
            time += Time.deltaTime;

            if (time >= 1)
            {
                closeBg.SetActive(true);
                isDragOver = false;
            }
        }

        print(time);
    }
}
