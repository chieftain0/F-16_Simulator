using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualLeftFlaperonControl : MonoBehaviour
{
    public string MasterObjectName = "F16";
    public float maxFlapDeflectionAngle = 25f;
    public float LandingFlapAngle = 10f;
    public float extraDeflectionAngle = 10f; 
    public float flapSpeed = 50f; 

    private bool isFlapOpen = false;
    private bool isLanding = false;

    private Quaternion initialRotation;
    private Quaternion targetRotation; 

    AirplaneController airplaneController;
    GameObject aircraft;

    private void Start()
    {
        aircraft = GameObject.Find(MasterObjectName);
        airplaneController = aircraft.GetComponent<AirplaneController>();
      
        initialRotation = transform.localRotation;
        targetRotation = initialRotation;
    }

    private void Update()
    {

        isFlapOpen = (airplaneController.Flap == 1f);
        isLanding = (airplaneController.isLanding == 1f);

        if (isFlapOpen == true)
        {
            targetRotation = initialRotation * Quaternion.Euler(Vector3.back * (maxFlapDeflectionAngle + (airplaneController.Roll * extraDeflectionAngle)));
        }
        else if (isFlapOpen == false)
        {
            if (isLanding == false)
            {
                targetRotation = initialRotation * Quaternion.Euler(Vector3.back * (airplaneController.Roll * extraDeflectionAngle));
            }
            else if (isLanding == true)
            {
                targetRotation = initialRotation * Quaternion.Euler(Vector3.back * (airplaneController.Roll * extraDeflectionAngle + LandingFlapAngle));
            }

        }
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, flapSpeed * Time.deltaTime);
    }
}
