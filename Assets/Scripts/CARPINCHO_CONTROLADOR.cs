using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CARPINCHO_CONTROLADOR : MonoBehaviour
{
 
    public GameObject carpincho;
    public Transform mano;

    private bool activo;

    
    void Update()
    {
        if (activo == true)
        {
            if(Input.GetKey("mouse 0")) //agarra con boton izq del mouse
            {
                carpincho.transform.SetParent(mano); //que la flor sea hija de la mano
                carpincho.transform.position = mano.position;
                carpincho.GetComponent<Rigidbody>().isKinematic = true;
            }
        }


        if (Input.GetKey("mouse 1")) //suelta con boton der del mouse
        {
            carpincho.transform.SetParent(null);
            carpincho.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private void OnTriggerEnter (Collider other) 
    { 
        if (other.tag == "Player") //si el usuario entra dentro del campo de deteccion puede agarrar la flor
        {
            activo = true;
            Debug.Log("aaa");
            
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.tag == "Player") //si sale del campo de deteccion ya no puede agarrar la flor
        {
            activo = false;
        }
    }
}
