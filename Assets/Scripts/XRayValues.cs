using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// XRayValues holds all the updated values for the position, height, and radius of the cylinder region from the bounding boxes.
public class XRayValues : MonoBehaviour
{
    /// The bounding box on the front face view.
    public GameObject front;
    /// The bounding box on the side face view.
    public GameObject side;
    /// The empty GameObject containing the head.
    public GameObject headEmpty;

    /// Position of the cylinder.
    static public Vector3 pos;
    /// Height of the cylinder.
    static public float height;
    ///Radius of the cylinder.
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
