using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakingStuff : MonoBehaviour
{
    Transform pos;

    private void Start()
    {
        pos = gameObject.transform;
    }

    void Update()
    {
        float x = Random.Range(pos.transform.localPosition.x + 1, pos.transform.localPosition.x - 1);
        float y = Random.Range(pos.transform.localPosition.y + 1, pos.transform.localPosition.y - 1);
        pos.transform.localPosition = new Vector3(x, y, 0);
    }
}
