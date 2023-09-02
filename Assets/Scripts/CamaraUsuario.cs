using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    public float sensibilidadMouse = 2.0f; // Sensibilidad del mouse
    public Transform personaje; // Referencia al transform del personaje para que la cámara lo siga

    private float rotacionX = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor en el centro de la pantalla
    }

    void Update()
    {
        // Captura el movimiento del mouse en los ejes X e Y
        float rotacionY = Input.GetAxis("Mouse X") * sensibilidadMouse;
        rotacionX -= Input.GetAxis("Mouse Y") * sensibilidadMouse;
        rotacionX = Mathf.Clamp(rotacionX, -90.0f, 90.0f); // Limita la rotación vertical

        // Aplica la rotación en el eje Y al personaje
        personaje.Rotate(Vector3.up * rotacionY);

        // Aplica la rotación en el eje X a la cámara
        transform.localRotation = Quaternion.Euler(rotacionX, 0.0f, 0.0f);
    }
}
