using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAJARO : MonoBehaviour
{
    public Transform[] waypoints; // Lista de puntos por los que el objeto se moverá
    public float speed = 5.0f; // Velocidad de movimiento del objeto
    public float rotationSpeed = 5.0f; // Velocidad de rotación del objeto
    public float floatAmplitude = 0.5f; // Amplitud de la oscilación vertical
    public float floatFrequency = 1.0f; // Frecuencia de la oscilación vertical
    private int currentWaypointIndex = 0; // Índice del punto actual

    private bool pajaroCurado = false;

    public AudioClip sonidoDarVenda;  
    public AudioSource audioSource;

    private void OnMouseDown()
    {
      Destroy( GameObject.FindGameObjectWithTag("Venda"));
       pajaroCurado = true;
        sonidoCurar();
      Debug.Log("Pajaro curado");      
    }

    private void Update()
    {
        if (pajaroCurado)
        {
            if (currentWaypointIndex < waypoints.Length)
            {
                Vector3 targetPosition = waypoints[currentWaypointIndex].position;

                // Mover el objeto hacia el punto objetivo
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

                // Oscilación vertical
                float verticalOffset = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
                Vector3 floatOffset = Vector3.up * verticalOffset;
                transform.position += floatOffset;

                // Rotar el objeto hacia el punto objetivo
                Vector3 directionToTarget = targetPosition - transform.position;
                if (directionToTarget != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                }

                // Comprobar si el objeto está lo suficientemente cerca del punto objetivo
                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {
                    currentWaypointIndex++; // Avanzar al siguiente punto
                }
            }
            else
            {
                // Si se han recorrido todos los puntos, reiniciar el circuito
                currentWaypointIndex = 0;
            }
        }
        
    }

    private void sonidoCurar()
    {
        if (pajaroCurado && sonidoDarVenda != null && audioSource != null)
        {
            audioSource.PlayOneShot(sonidoDarVenda);
            Debug.Log("AA");
        }
    }


}


