using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EngineSoundControl : MonoBehaviour
{
    public string MasterObjectName = "F16";
    public AudioSource audioSource = null;
    public float volumeIncreaseSpeed = 3.0f;
    AirplaneController airplaneController;
    GameObject aircraft;

    void Start()
    {
        aircraft = GameObject.Find(MasterObjectName);
        airplaneController = aircraft.GetComponent<AirplaneController>();

    }

    // Update is called once per frame
    void Update()
    {
        if(airplaneController.engineState == 0f)
        {
            audioSource.volume = 0f;
        }
        else
        {
            //audioSource.volume = Mathf.Clamp(airplaneController.thrustPercent, 0.4f, 1f);
            float targetVolume = Mathf.Clamp(airplaneController.thrustPercent, 0.4f, 1f);
            audioSource.volume = Mathf.MoveTowards(audioSource.volume, targetVolume, volumeIncreaseSpeed * Time.deltaTime);
        }
    }
}
