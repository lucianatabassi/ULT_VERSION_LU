using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USUARIO : MonoBehaviour
{

    //ESTE SCRIPT ES CODIGO VIEJO PERO LO DEJE POR LAS DUDAS. NO SE ESTA USANDO
    private Rigidbody rb;
    public float velMov;

    public Transform camara;
    public Vector2 sensibilidad;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //camara = transform.Find("Camera"); //buscar la camara del personaje
        Cursor.lockState = CursorLockMode.Locked; //evitar que el cursor salga de la ventana

    }

    private void Movimiento()
    {
        float horMov = Input.GetAxisRaw("Horizontal");
        float verMov = Input.GetAxisRaw("Vertical");

        Vector3 vel = Vector3.zero;

        if (horMov != 0 || verMov != 0) // se esta moviendo en alguna direccion
        {
            Vector3 dir = (transform.forward * verMov + transform.right * horMov).normalized; // forward indica hacia donde apunta el jugador (flecha azul)
            vel = dir * velMov;
        }
        vel.y = rb.velocity.y;
        rb.velocity = vel; //evitar movimiento automatico

    }

    private void MovCamara()
    {
        float hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Mouse Y");

        if (hor != 0 ) // se esta la camara rotando horizontalmente
        {
            transform.Rotate(0, hor * sensibilidad.x, 0); //permite girar a der o izq
        }

        if (ver != 0 ) // rotando camara verticalmente
        {
            Vector3 rotacion = camara.localEulerAngles;
            rotacion.x = (rotacion.x - ver * sensibilidad.y + 360) % 360;  //siempre se mantiene entre 0 y 360 grados
            if (rotacion.x > 80 && rotacion.x < 180)
            {
                rotacion.x = 80;
            } else if (rotacion.x < 280 && rotacion.x > 180)
            {
                rotacion.x = 280;
            }
            camara.localEulerAngles = rotacion;
            //camara.Rotate(-ver * sensibilidad.y, 0, 0);
            
        }
    }

    void Update()
    {
        Movimiento();
       MovCamara();
         
    }

   /* private void OnCollisionEnter (Collision collision)
    {
        FLOR_CONTROLLER flor = collision.gameObject.GetComponent<FLOR_CONTROLLER>();

        if (flor != null) // si colisiona con la flor la agarra
        {
            flor.CollectItem();
        }
    }*/
}
