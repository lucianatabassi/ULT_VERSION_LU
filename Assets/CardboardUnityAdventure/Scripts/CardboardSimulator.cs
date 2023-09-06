using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardboardSimulator : MonoBehaviour
{
    public bool UseCardboardSimulator = true;

    [SerializeField] private float horizontalSpeed = 0.5f;
    [SerializeField] private float verticalSpeed = 0.5f;
    [SerializeField] private float rotationX = 0.0f;
    [SerializeField] private float rotationY = 0.0f;
    public Transform personaje;
    private Camera cam;
    private Gyroscope gyro;

    void Start() 
    {
#if UNITY_EDITOR
        cam = Camera.main;
#endif
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true; // Habilitamos el giroscopio

            // Ajusta la orientación inicial del objeto al giroscopio
            transform.rotation = Quaternion.Euler(90, 90, 0) * (new Quaternion(-gyro.attitude.x, -gyro.attitude.y, gyro.attitude.z, gyro.attitude.w));
        }
        else
        {
            Debug.LogError("El dispositivo no es compatible con el giroscopio.");
        }
    }

    void Update()
    {
#if UNITY_EDITOR
        if (!UseCardboardSimulator)
            return;
        
          float rotationY = Input.GetAxis("Mouse X") * horizontalSpeed;
            float rotationX = Input.GetAxis("Mouse Y") * verticalSpeed; 
     
            rotationX = Mathf.Clamp(rotationX, -45, 45);

            personaje.Rotate(Vector3.up * rotationY); 
            cam.transform.localEulerAngles = new Vector3(rotationX, rotationY, 0.0f);
        
#endif

        if (gyro != null)
        {
            transform.rotation = Quaternion.Euler(90, 90, 0) * (new Quaternion(-gyro.attitude.x, -gyro.attitude.y, gyro.attitude.z, gyro.attitude.w));
        }
    }

    public void UpdatePlayerPositonSimulator()
    {
        rotationX = 0;
        rotationY = cam.transform.localEulerAngles.y;
    }

}
