using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualRightElevatorsControl : MonoBehaviour
{
    public string MasterObjectName = "F16";
    public float PitchDeflectionAngle = 15f;
    public float RollDeflectionAngle = 5f;
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
        targetRotation = initialRotation * Quaternion.Euler(Vector3.forward * (airplaneController.Pitch * PitchDeflectionAngle + airplaneController.Roll * RollDeflectionAngle));
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, deflectionSpeed * Time.deltaTime);
    }
}
