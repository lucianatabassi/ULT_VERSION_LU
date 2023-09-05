using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJoystick : MonoBehaviour
{
    public CharacterController controller;
    public float velocidadMovimiento = 6f;
    public float velocidadRotacion = 3f;

    private float gravedad = -9.81f;
    private Vector3 velocidadVertical;

    void Update()
    {
        // Captura el movimiento del joystick.
        float horizontal = Input.GetAxis("HorizontalJoystick");
        float vertical = Input.GetAxis("VerticalJoystick");

        // Calcula la dirección de movimiento en base a la cámara.
        Vector3 direccion = transform.forward * vertical + transform.right * horizontal;

        // Aplica movimiento.
        controller.Move(direccion.normalized * velocidadMovimiento * Time.deltaTime);

        // Captura la rotación del joystick derecho (si es un controlador con dos joysticks).
        float rotacionJoystickX = Input.GetAxis("RightJoystickX");

        // Aplica rotación en función del movimiento del joystick derecho.
        if (rotacionJoystickX != 0f)
        {
            transform.Rotate(Vector3.up * rotacionJoystickX * velocidadRotacion);
        }

        // Aplica gravedad al personaje.
       /* velocidadVertical.y += gravedad * Time.deltaTime;
        controller.Move(velocidadVertical * Time.deltaTime);*/
    }
}
