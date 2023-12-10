using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualRudderControl : MonoBehaviour
{
    public string MasterObjectName = "F16";
    

    public float maxRudderAngle = 25f;   
    public float rudderSpeed = 5f;       

    private Quaternion initialRotation; 
    private Quaternion targetRotation; 


    AirplaneController airplaneController;
    GameObject aircraft;

    void Start()
    {
        aircraft = GameObject.Find(MasterObjectName);
        airplaneController = aircraft.GetComponent<AirplaneController>();

        initialRotation = transform.localRotation;
        targetRotation = initialRotation;
    }

    void Update()
    {

        targetRotation = initialRotation * Quaternion.Euler(Vector3.up * (maxRudderAngle * airplaneController.Yaw));
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rudderSpeed * Time.deltaTime);
    }
}
