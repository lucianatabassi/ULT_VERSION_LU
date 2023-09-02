using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOV_USUARIO : MonoBehaviour
{
    public CharacterController controller; //el character controller es un componenten de unity, con esto es mas facil hacer los movimientos

    public float vel = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal"); //con esta linea de codigo unity ya sabe cuales son las teclas por defecto que se usan para moverse
        float z = Input.GetAxis("Vertical"); //lo de arriba

        Vector3 mover = transform.right * x + transform.forward * z;

        controller.Move(mover * vel * Time.deltaTime);  
    }
}
