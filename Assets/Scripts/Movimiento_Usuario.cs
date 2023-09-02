using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    
    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Aplica el movimiento al personaje
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0.0f, movimientoVertical) * velocidadMovimiento * Time.deltaTime;
        transform.Translate(movimiento);
    }
}
