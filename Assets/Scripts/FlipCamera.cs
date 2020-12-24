using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCamera : MonoBehaviour
{
    public Camera mainCam;
    public Camera sideCam;

    public GameObject headEmpty;

    public GameObject leftBox;
    public GameObject rightBox;

    static public bool isFrontView = true;

    int camDist = 3;

    public void Update()
    {
        if (SceneHandler.isXRay)
            return;

        //Click
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;

            if (pos.x > Screen.width / 2 && isFrontView)
            {
                isFrontView = false;
                buttonFlipCamera();
            }
            else if(pos.x < Screen.width / 2 && !isFrontView)
            {
                isFrontView = true;
                buttonFlipCamera();
            }
        }
        //Mobile
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Vector3 pos = Input.touches[0].position;

            if (pos.x > Screen.width / 2 && isFrontView)
            {
                isFrontView = false;
                buttonFlipCamera();
            }
            else if (pos.x < Screen.width / 2 && !isFrontView)
            {
                isFrontView = true;
                buttonFlipCamera();
            }
        }
    }

    public void resetView()
    {
        if (!isFrontView)
        {
            isFrontView = true;
            buttonFlipCamera();
        }
    }

    public void buttonFlipCamera()
    {
        if(isFrontView)
        {
            headEmpty.transform.Rotate(new Vector3(0, -90, 0));
            sideCam.transform.Rotate(new Vector3(0, -180, 0));
            sideCam.transform.position = new Vector3(camDist, 0, 0) + headEmpty.transform.position;

            //rightBox.layer = LayerMask.NameToLayer("Side Camera");
            //leftBox.layer = LayerMask.NameToLayer("Front Camera");

            SetLayerRecursively(rightBox, LayerMask.NameToLayer("Side Camera"));
            SetLayerRecursively(leftBox, LayerMask.NameToLayer("Front Camera"));

            sideCam.rect = new Rect(0.5f, 0, 0.5f, 1);
            mainCam.rect = new Rect(0, 0, 0.5f, 1);
        }
        else
        {
            headEmpty.transform.Rotate(new Vector3(0, 90, 0));
            sideCam.transform.Rotate(new Vector3(0, 180, 0));
            sideCam.transform.position = new Vector3(-camDist, 0, 0) + headEmpty.transform.position;

            //leftBox.layer = LayerMask.NameToLayer("Side Camera");
            //rightBox.layer = LayerMask.NameToLayer("Front Camera");

            SetLayerRecursively(rightBox, LayerMask.NameToLayer("Front Camera"));
            SetLayerRecursively(leftBox, LayerMask.NameToLayer("Side Camera"));

            mainCam.rect = new Rect(0.5f, 0, 0.5f, 1);
            sideCam.rect = new Rect(0, 0, 0.5f, 1);
        }
    }
    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        if (null == obj)
        {
            return;
        }

        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            if (null == child)
            {
                continue;
            }
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }
}
