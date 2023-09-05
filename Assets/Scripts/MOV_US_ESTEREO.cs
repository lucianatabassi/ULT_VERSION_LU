using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOV_US_ESTEREO : MonoBehaviour
{
    public CharacterController controller; // El Character Controller es un componente de Unity que facilita el movimiento del personaje.

    public float velocidadMovimiento = 6f; // Velocidad de movimiento del personaje.
    public float velocidadRotacion = 3f;   // Velocidad de rotación del personaje.

   // private float gravedad = -9.81f;       // Gravedad aplicada al personaje.
    private Vector3 velocidadVertical;      // Velocidad vertical del personaje.

    void Update()
    {
        // Captura el movimiento del input.
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calcula la dirección de movimiento en base a la cámara.
        Vector3 direccion = transform.forward * vertical + transform.right * horizontal;

        // Aplica movimiento.
        controller.Move(direccion.normalized * velocidadMovimiento * Time.deltaTime);

        // Captura la rotación del mouse.
        float rotacionMouseX = Input.GetAxis("Mouse X");

        // Aplica rotación en función del movimiento del mouse.
        if (rotacionMouseX != 0f)
        {
            transform.Rotate(Vector3.up * rotacionMouseX * velocidadRotacion);
        }

        // Aplica gravedad al personaje.
      /*  velocidadVertical.y += gravedad * Time.deltaTime;
        controller.Move(velocidadVertical * Time.deltaTime);*/
    }
}
