using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOV_USUARIO : MonoBehaviour
{
    public CharacterController controller; //el character controller es un componenten de unity, con esto es mas facil hacer los movimientos

    public float vel = 10f;
    public float gravedad = -9.8f;
    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal"); //con esta linea de codigo unity ya sabe cuales son las teclas por defecto que se usan para moverse
        float z = Input.GetAxis("Vertical"); //lo de arriba

        Vector3 mover = transform.right * x + transform.forward * z;

        controller.Move(mover * vel * Time.deltaTime);  
    }
}
