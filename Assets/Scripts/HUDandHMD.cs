using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDandHMD : MonoBehaviour
{
    public GameObject HMD;
    public GameObject HUD;
    public Camera VRCam;

    public float angleVertical;
    public float angleHorizontal;


    void Start()
    {
        HUD.SetActive(true);
        HMD.SetActive(false);
    }

    void Update()
    {
        angleVertical = VRCam.transform.localEulerAngles.x;
        angleHorizontal = VRCam.transform.localEulerAngles.y;

        if ((angleVertical > 345f || angleVertical < 15f) && (angleHorizontal > 345f || angleHorizontal < 15f))
        {
                HUD.SetActive(true);
                HMD.SetActive(false);
        }
        else
        {
                HMD.SetActive(true);
                HUD.SetActive(false);
        }
        
    }
}
