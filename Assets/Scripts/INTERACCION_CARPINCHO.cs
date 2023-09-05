
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionCarpincho : MonoBehaviour
{
    public GameObject objetoA;            // El objeto A que debe hacer contacto con el objeto B.
    public GameObject objetoB;            // El objeto B que debe ser contactado por el objeto A.
    public GameObject objetoC1, objetoC2;            // El objeto C que se destruirá.
    public GameObject objetoD;            // El objeto D que aparecerá.
    public AudioClip sonidoDestruccionC;  // El clip de sonido a reproducir al destruir el objeto C.
    public AudioSource audioSource;       // El AudioSource para reproducir el sonido.
    public Vector3 posicionObjetoD;       // La posición donde aparecerá el objeto D.


    private bool objetosReemplazados = false;

    private void Update()
    {
        if (!objetosReemplazados)
        {
            float distanciaAB = Vector3.Distance(objetoA.transform.position, objetoB.transform.position);

            if (Input.GetKey("mouse 0") && distanciaAB < 0.5f) // Ajusta la distancia para el contacto.
            {
                if (sonidoDestruccionC != null && audioSource != null)
                {
                    audioSource.PlayOneShot(sonidoDestruccionC);
                }

                Destroy(objetoA);
                Destroy(objetoC1);
                Destroy(objetoC2);

                objetoB.SetActive(false);
                Instantiate(objetoD, posicionObjetoD, objetoD.transform.rotation);


                objetosReemplazados = true;
            }
        }
    }
}

