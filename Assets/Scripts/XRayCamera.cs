using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRayCamera : MonoBehaviour
{
    public Light light;

    void OnPreCull()
    {
        light.enabled = false;
    }

    void OnPostRender()
    {
        light.enabled = true;
    }
}
