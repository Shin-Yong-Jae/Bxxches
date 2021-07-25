using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Elemental_ImageShower : MonoBehaviour
{
    public Image image;
    public Camera camera;
    private Transform target;
    // Use this for initialization
    void Start()
    {
        target = GetComponent<Transform>();
    }
    void Update()
    {
        Vector3 screenPos = camera.WorldToScreenPoint(target.position);
        float x = screenPos.x;
        image.transform.position = new Vector3(screenPos.x,screenPos.y);
    }
}