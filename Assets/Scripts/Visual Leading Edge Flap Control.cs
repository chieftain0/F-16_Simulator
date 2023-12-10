using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualLeadingEdgeFlapControl : MonoBehaviour
{
    public string MasterObjectName = "F16";
    public float LeadingEdgeDeflectionAngle = 10f;
    public float deflectionSpeed = 50f;

    AirplaneController airplaneController;
    GameObject aircraft;

    private Quaternion initialRotation;
    private Quaternion targetRotation; 
    

    void Start()
    {
        aircraft = GameObject.Find(MasterObjectName);
        airplaneController = aircraft.GetComponent<AirplaneController>();

        initialRotation = transform.localRotation;
        targetRotation = initialRotation;
    }


    void Update()
    {
        if (airplaneController.Pitch < 0)
        {
            targetRotation = initialRotation * Quaternion.Euler(Vector3.forward * (airplaneController.Pitch * -LeadingEdgeDeflectionAngle));
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, deflectionSpeed * Time.deltaTime);
        }
    }
}
