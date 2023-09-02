using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VENDA_INTERACCION : MonoBehaviour
{
    public GameObject hoja;
    public GameObject rama;
    public GameObject venda;
    public GameObject parentObject;
    private GameObject miVenda;

    private bool agarroHoja = false;
    private bool agarroRama = false;
    //private bool vendaactiva = false;

    public AudioClip sonidoAgarrar;
    public AudioSource audioSource;
    //public Transform mano;
    private PAJARO bird;

    void Start()
    {
        venda.SetActive(false);

       bird = FindObjectOfType<PAJARO>();
    }
    void Update()
    {
       

        if (!agarroHoja && Input.GetKeyDown("mouse 0") && enRango(hoja))
        {
            Destroy(hoja);
            agarroHoja = true;
            audioSource.PlayOneShot(sonidoAgarrar);
        }

        if (!agarroRama && Input.GetKeyDown("mouse 0") && enRango(rama))
        {
            Destroy(rama); 
            agarroRama = true;
            audioSource.PlayOneShot(sonidoAgarrar);
        }

        if (agarroHoja && agarroRama && venda != null) 
        {
           
           venda.SetActive(true);
                       
        }




    }



    private bool enRango(GameObject obj)
    {
        float distance = Vector3.Distance(obj.transform.position, transform.position);
        return distance <= 2f; // Adjust the range as needed
    }

  



}
