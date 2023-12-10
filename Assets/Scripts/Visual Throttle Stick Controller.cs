using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualThrottleStickController : MonoBehaviour
{
    public string MasterObjectName = "F16";
    public float ThrottleStickRotationAngle = 5f; 
    public float deflectionSpeed = 100f;

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

    // Update is called once per frame
    void Update()
    {
        targetRotation = initialRotation * Quaternion.Euler(Vector3.up * (airplaneController.thrustPercent * -ThrottleStickRotationAngle));
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, deflectionSpeed * Time.deltaTime);
    }
}
