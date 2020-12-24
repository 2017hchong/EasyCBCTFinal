using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ARHandler : MonoBehaviour
{
	public GameObject arAssets;

	public GameObject groundPlaneStage;
	public GameObject xRayHeadEmpty;
	public GameObject xRayHead;

	public CameraDrag camScript;

    public Button yourButton;

    GameObject ARCam;

    GameObject MainCam;

    GameObject XRayCam;

    GameObject PlaneFinder;

    GameObject GroundPlaneStage;

    bool isARMode = false;
    // Start is called before the first frame update
    void Start()
    {
    	arAssets.transform.GetChild(0).position = new Vector3(0,0,-0.7f);

    	ARCam = GameObject.Find("ARCamera");
    	MainCam = GameObject.Find("MainCamera");
    	XRayCam = GameObject.Find("Camera");
    	PlaneFinder = GameObject.Find("Plane Finder");
    	GroundPlaneStage = GameObject.Find("Ground Plane Stage");

    	NonARMode();

        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(ChangeMode);
    }

    void ChangeMode() 
    {
    	if(isARMode) {
    		NonARMode();
    	} else {
    		ARMode();
    	}
    }

    public void ARMode() 
    {
    	isARMode = true;
        GroundPlaneStage.transform.position = new Vector3(0,0,0);

    	xRayHead.transform.rotation = Quaternion.Euler(-90.0f,0,180.0f);
    	xRayHead.transform.position = new Vector3(0,0.2f,0);
    	xRayHead.transform.parent = groundPlaneStage.transform;

        MainCam.tag = "Untagged";
        ARCam.tag = "MainCamera";

        XRayCam.SetActive(false);
        PlaneFinder.SetActive(true);
    }

    public void NonARMode()
    {
    	Transform arCamTrans = ARCam.transform;
    	Vector3 Dist = arCamTrans.position - xRayHead.transform.position;

        MainCam.tag = "MainCamera";
        ARCam.tag = "Untagged";

        XRayCam.SetActive(true);
        PlaneFinder.SetActive(false);

    	isARMode = false;

    	xRayHead.transform.parent = xRayHeadEmpty.transform;
    	xRayHead.transform.position = new Vector3(0,0,0);
    	xRayHead.transform.rotation = Quaternion.Euler(-90.0f,0,180.0f);
    	camScript.SetCamera(Dist);
    }
}
