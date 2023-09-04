using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BASURA_INTERACCION : MonoBehaviour
{
    public GameObject prefabBasura; // El prefab de tu objeto
    public int cantBasura = 3; // Número de objetos para recoger antes de eliminarlos
    private List<GameObject> recolectarBasura = new List<GameObject>();

    void Update()
    {
        if ( Input.GetKeyDown("mouse 0") && enRango(prefabBasura))
        {
            CollectObject(prefabBasura);
        }
    }

    // Método para agregar objetos a la lista cuando se recogen
    public void CollectObject(GameObject recolectar)
    {
        recolectarBasura.Add(recolectar);
        CheckForMatch();
    }

    // Método para verificar si se han recogido suficientes objetos idénticos
    private void CheckForMatch()
    {
        if (recolectarBasura.Count >= cantBasura)
        {
            bool areObjectsIdentical = true;
            for (int i = 1; i < recolectarBasura.Count; i++)
            {
                if (recolectarBasura[i] != recolectarBasura[0])
                {
                    areObjectsIdentical = false;
                    break;
                }
            }

            if (areObjectsIdentical)
            {
                // Eliminar objetos idénticos
                foreach (var obj in recolectarBasura)
                {
                    Destroy(obj);
                }
                recolectarBasura.Clear();
            }
            else
            {
                // No son objetos idénticos, limpiar la lista
                recolectarBasura.Clear();
            }
        }
    }

    private bool enRango(GameObject obj)
    {
        float distance = Vector3.Distance(obj.transform.position, transform.position);
        return distance <= 2f; // Adjust the range as needed
    }
}

