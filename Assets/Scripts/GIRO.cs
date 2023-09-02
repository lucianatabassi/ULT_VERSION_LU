using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroCameraController : MonoBehaviour
{
    private Gyroscope gyro;

    void Start()
    {
        // Verificamos si el dispositivo tiene giroscopio
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
        // Actualizamos la rotación del objeto en tiempo real con los datos del giroscopio
        if (gyro != null)
        {
            transform.rotation = Quaternion.Euler(90, 90, 0) * (new Quaternion(-gyro.attitude.x, -gyro.attitude.y, gyro.attitude.z, gyro.attitude.w));
        }
    }
}