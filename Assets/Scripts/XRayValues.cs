using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRayValues : MonoBehaviour
{
    public GameObject front;
    public GameObject side;
    public GameObject headEmpty;

    static public Vector3 pos;
    static public float height;
    static public float radius;


    // Update is called once per frame
    void Update()
    {
        pos = new Vector3(front.transform.localPosition.x, front.transform.localPosition.y, side.transform.localPosition.z); 
        pos = pos / 7.0f;


        height = front.transform.localScale.y / 7.0f;
        radius = front.transform.localScale.x / 7.0f / 2.0f;
    }
}
