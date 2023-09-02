using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReemplazoDeObjeto : MonoBehaviour
{
    public GameObject objetoOriginal;
    public GameObject objetoReemplazo;

    public void ReemplazarObjeto()
    {
        objetoOriginal.SetActive(false); // Desactivar el objeto original
        objetoReemplazo.SetActive(true); // Activar el objeto de reemplazo
    }
}
