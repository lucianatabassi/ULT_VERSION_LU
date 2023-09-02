using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproducirSonidoAlAcercar : MonoBehaviour
{
    public string playerTag = "Player"; // Etiqueta del jugador
    public Transform abeja; // Objeto "abeja"
    public float distanciaMaxima = 10f; // Distancia máxima a la que se escucha el sonido
    public float distanciaMinima = 2f; // Distancia mínima a partir de la cual se activa el sonido
    public float tiempoEntreSonidos = 5f; // Tiempo mínimo entre reproducciones de sonido
    public float probabilidadReproduccion = 0.35f; // Probabilidad de reproducción de sonido
    public AudioSource audioSource;
    public AudioClip[] sonidos; // Array de clips de sonido

    private float tiempoUltimoSonido = 0f;
    private AudioClip ultimoSonidoReproducido;

    private void Update()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag(playerTag); // Encuentra el jugador

        if (jugador != null)
        {
            // Calcula la distancia entre el jugador y la abeja
            float distancia = Vector3.Distance(jugador.transform.position, abeja.position);

            // Si el jugador está dentro del rango de distancia
            if (distancia <= distanciaMaxima && distancia >= distanciaMinima)
            {
                // Calcula el factor de volumen en función de la distancia
                float factorVolumen = 1f - Mathf.Clamp01((distancia - distanciaMinima) / (distanciaMaxima - distanciaMinima));

                // Establece el volumen del AudioSource en función del factor
                audioSource.volume = factorVolumen;

                // Verifica si ha pasado suficiente tiempo desde el último sonido
                if (Time.time - tiempoUltimoSonido >= tiempoEntreSonidos)
                {
                    // Reproduce el sonido con una probabilidad
                    if (Random.value < probabilidadReproduccion)
                    {
                        // Elige un clip de sonido al azar que no sea el último reproducido
                        AudioClip clipAleatorio = ObtenerSonidoAleatorioDistinto(ultimoSonidoReproducido);
                        if (clipAleatorio != null)
                        {
                            audioSource.PlayOneShot(clipAleatorio);
                            tiempoUltimoSonido = Time.time;
                            ultimoSonidoReproducido = clipAleatorio;
                        }
                    }
                }
            }
            else
            {
                // Detiene el sonido cuando el jugador está fuera del rango
                audioSource.Stop();
            }
        }
    }

    private AudioClip ObtenerSonidoAleatorioDistinto(AudioClip sonidoExcluido)
    {
        AudioClip clipAleatorio = sonidos[Random.Range(0, sonidos.Length)];

        // Intenta seleccionar un sonido diferente al sonido excluido
        for (int i = 0; i < sonidos.Length; i++)
        {
            if (clipAleatorio != sonidoExcluido)
            {
                return clipAleatorio;
            }
            clipAleatorio = sonidos[Random.Range(0, sonidos.Length)];
        }

        // Si no se encuentra un sonido diferente, devuelve null
        return null;
    }
}
