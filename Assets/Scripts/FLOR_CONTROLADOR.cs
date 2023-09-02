using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLOR_CONTROLADOR : MonoBehaviour
{
    public GameObject flor;
    public Transform mano;

    private bool activo;

    
    void Update()
    {
        if (activo == true)
        {
            if(Input.GetKey("mouse 0")) //agarra con boton izq del mouse
            {
                flor.transform.SetParent(mano); //que la flor sea hija de la mano
                flor.transform.position = mano.position;
                flor.GetComponent<Rigidbody>().isKinematic = true;
            }
        }


        if (Input.GetKey("mouse 1")) //suelta con boton der del mouse
        {
            flor.transform.SetParent(null);
            flor.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private void OnTriggerEnter (Collider other) 
    { 
        if (other.tag == "Player") //si el usuario entra dentro del campo de deteccion puede agarrar la flor
        {
            activo = true;
            //Debug.Log("aaa");
            
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
