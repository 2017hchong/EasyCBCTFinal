using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClippingCyllinder : MonoBehaviour
{
    //material we pass the values to
    public Material[] mat;

    public static float height;
    public static float radius;

    public static Vector3 position;

    public GameObject xRayHead;
    //position = center
    //transform.up = cyllinder height

    Plane planeUp;
    Plane planeDown;
    void Start()
    {
        transform.up = Vector3.up;
        //transform.position = new Vector3(0, 0, 0);

        //height = 0.15f;
        //radius = 0.03f;

        //height = 0.05f;
        //radius = 0.02f;

    }

    // Update is called once per frame
    void Update()
    {
        position = XRayValues.pos;
        transform.position = XRayValues.pos;

        height = XRayValues.height;
        radius = XRayValues.radius;

        //create clipping planes
        planeUp = new Plane(transform.up, transform.position + transform.up * height / 2);
        planeDown = new Plane(-1 * transform.up, transform.position + -1 * transform.up * height / 2);

        foreach (Material m in mat)
        {
            //transfer values from plane to vector4
            Vector4 planeRepresentationUp = new Vector4(planeUp.normal.x, planeUp.normal.y, planeUp.normal.z, planeUp.distance);
            //pass vector to shader
            m.SetVector("_PlaneUp", planeRepresentationUp);

            //transfer values from plane to vector4
            Vector4 planeRepresentationDown = new Vector4(planeDown.normal.x, planeDown.normal.y, planeDown.normal.z, planeDown.distance);
            //pass vector to shader
            m.SetVector("_PlaneDown", planeRepresentationDown);

            //transfer cylinder values
            Vector4 cylinderRepresentation = new Vector4(transform.position.x, transform.position.y, transform.position.z, radius);
            //pass vector to shader
            m.SetVector("_Cylinder", cylinderRepresentation);

            m.SetVector("_Position", xRayHead.transform.position);
        }

        ////create cylinder
        //GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        //cylinder.transform.position = new Vector3(-2, 1, 0);
    }
}
