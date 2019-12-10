using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CJugador : MonoBehaviour
{

    //variables
    public float velocidad = 10;
    public Text tmonedas;
    public Text tvictoria;
    public string siguienteEscena = "";


    private Rigidbody miRigidbody;
    private Vector3 posicionInicial;
    bool haSalido;
    int monedas = 0;
   


    // Start is called before the first frame update
    void Start()
    {
        miRigidbody = GetComponent<Rigidbody>();
        posicionInicial = transform.position; //coja la posicion inicial
        tvictoria.enabled = false;//para que no se vea el texto
        haSalido = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!haSalido)
            {
                //aplicar fuerzas para mover el cuerpo al pulsar las teclas
                //ejes 
                float vertical = Input.GetAxis("Vertical");//eje x
                float horizontal = Input.GetAxis("Horizontal");// eje z

          //  miRigidbody.MovePosition(miRigidbody.position + (new Vector3(vertical, 0, horizontal) * velocidad*Time.deltaTime)); //si se mueve muy rapido al tener muchos elementos en la escena puede cambiarse para que no se mueva por fuerzas y tener mejor control
            //se multiplica por la velocidad para cambiar lo rapido que va
            miRigidbody.AddForce(new Vector3(vertical, 0, horizontal) * velocidad);
            }

    }

    //trigger  objeto que toca el jugador y sucede algo
    private void OnTriggerEnter(Collider other)
    {
        //si su tag es salida
        if (other.CompareTag("salida"))
        {
            haSalido = true;
            tvictoria.enabled = true;//hace visible el texto victoria
            miRigidbody.velocity = Vector3.zero; //que no se mueva en la posicion inicial hasta que lo movamos
            miRigidbody.angularVelocity = Vector3.zero;//que no gire
            SceneManager.LoadScene(siguienteEscena);

        }
        else if (other.CompareTag("moneda")) {
            //si está activo ponerlo inactivo para que desaparezca
            other.gameObject.SetActive(false);
            //contar las monedas
            monedas = monedas + 1;
            tmonedas.text = "Monedas: " + monedas;


        }
        else if (other.CompareTag("enemigo"))
        {
            miRigidbody.MovePosition(posicionInicial);//que vuelva a la posicion inicial si toca un enemigo
            miRigidbody.velocity = Vector3.zero; //que no se mueva en la posicion inicial hasta que lo movamos
            miRigidbody.angularVelocity = Vector3.zero;//que no gire
            monedas = 0;
            tmonedas.text = "Monedas: 0";


        }

    }
}
