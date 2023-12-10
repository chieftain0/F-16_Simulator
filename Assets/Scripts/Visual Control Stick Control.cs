using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualControlStickControl : MonoBehaviour
{
    public string MasterObjectName = "F16";
    public float AllDirectionDeflectionAngle = 10f; 
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

    void Update()
    {
        targetRotation = initialRotation * Quaternion.Euler(Vector3.forward * (airplaneController.Pitch * AllDirectionDeflectionAngle) + Vector3.right * (airplaneController.Roll * AllDirectionDeflectionAngle));
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, deflectionSpeed * Time.deltaTime);
    }
}
