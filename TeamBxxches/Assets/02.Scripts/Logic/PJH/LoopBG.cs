using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBG : MonoBehaviour //배경 이동시키는 클래스
{
    [SerializeField] Transform startTransform;
    
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime);

        if (transform.localPosition.x >= -startTransform.localPosition.x)
        {
            transform.localPosition += startTransform.localPosition * 2;
        }
    }
}
