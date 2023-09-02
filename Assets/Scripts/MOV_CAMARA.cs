using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOV_CAMARA : MonoBehaviour
{

    public float sensibilidad = 80f;
    public Transform usuario;
    float xRotation = 0;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //para que el cursor no aparezca cuando se esta ejecutando
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        usuario.Rotate(Vector3.up * mouseX);
    }
}
