using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public float speed = 100;
     private float X;
     private float Y;
    private float startingPosition;

    public GameObject target;
    public GameObject camera;

    void Update()
    {
    	if(!SceneHandler.isXRay)
    		return;
        // if(Input.GetMouseButton(0)) {
        //      transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * speed, -Input.GetAxis("Mouse X") * speed, 0), Space.World);
        //      // X = transform.rotation.eulerAngles.x;
        //      // Y = transform.rotation.eulerAngles.y;
        //      // transform.rotation = Quaternion.Euler(X, Y, 0);
        //  }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
             case TouchPhase.Began:
                 startingPosition = touch.position.x;
                 break;
             case TouchPhase.Moved:
                 if (startingPosition > touch.position.x)
                 {
                     transform.Rotate(Vector3.up, -speed * Time.deltaTime);
                 }
                 else if (startingPosition < touch.position.x)
                 {
                     transform.Rotate(Vector3.up, speed * Time.deltaTime);
                 }
                 break;
             case TouchPhase.Ended:
                 Debug.Log("Touch Phase Ended.");
                 break;
            }
        } else if(Input.GetMouseButton(0))
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * speed/10, 0), Space.World);
        }
    }

    public void SetCamera(Vector3 dist)
    {
        camera.transform.position = target.transform.position + dist;
        camera.transform.LookAt(target.transform);
        // Vector3 Dist = Vector3.Distance(Camera.main.transform.position,transform.position) 
    }
 
 
}