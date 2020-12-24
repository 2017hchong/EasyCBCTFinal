using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{
    public Camera xRayCam;
    public Camera mainCam;
    public Camera sideCam;

    float viewPortX = 0.775f;
    float viewPortY = 0.025f;
    float viewPortW = 0.2f;
    float viewPortH = 0.2f;

    //the buttons that overlay ontop of the mini screen
    public GameObject xRayButtonCanvas;
    public GameObject mainButtonCanvas;
    public GameObject sideButtonCanvas;

    static public bool isXRay;

    public GameObject ARButton;

    public FlipCamera flipScript;

    // Start is called before the first frame update
    void Start()
    {
        SetUIAsMainPage();
    }

    public void SetUIAsMainPage()
    {
        isXRay = false;

        flipScript.resetView();

        xRayButtonCanvas.SetActive(true);

        mainButtonCanvas.SetActive(false);
        sideButtonCanvas.SetActive(false);

        // ARButton.GetComponent<ARHandler>().NonARMode();
        ARButton.SetActive(false);

        sideCam.rect = new Rect(0.5f, 0, 0.5f, 1);
        mainCam.rect = new Rect(0, 0, 0.5f, 1);

        xRayCam.rect = new Rect(viewPortX, viewPortY, viewPortW, viewPortH);

        xRayCam.tag = "Untagged";
        mainCam.tag = "MainCamera";

        sideCam.depth = 0;
        mainCam.depth = 0;
        xRayCam.depth = 2;
    }

    public void SetXRayAsMainPage()
    {
        isXRay = true;

        flipScript.resetView();

        xRayButtonCanvas.SetActive(false);

        mainButtonCanvas.SetActive(true);
        sideButtonCanvas.SetActive(true);

        ARButton.SetActive(true);

        sideCam.rect = new Rect(viewPortX + viewPortW/2, viewPortY, viewPortW/2, viewPortH);
        mainCam.rect = new Rect(viewPortX, viewPortY, viewPortW/2, viewPortH);

        xRayCam.rect = new Rect(0,0,1,1);

        mainCam.tag = "Untagged";
        xRayCam.tag = "MainCamera";

        sideCam.depth = 2;
        mainCam.depth = 2;
        xRayCam.depth = 0;
    }


}
