using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CpatrullaEnemigo : MonoBehaviour
{
    public Transform desde;
    public Transform hasta;
    public float velocidad;

    bool llendo;

    
    // Start is called before the first frame update
    void Start()
    {
        llendo = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 objetivo;
        if (llendo)
        {
            objetivo = hasta.position;
        }
        else {
            objetivo = desde.position;

        }

        //distancia al objetivo
        Vector3 distancia = objetivo - transform.position;
        //cuanto se desplaza
        Vector3 desplazamiento = distancia.normalized * Time.deltaTime;

        //comprobar que no se desplaza de mas
        if (desplazamiento.sqrMagnitude >= distancia.sqrMagnitude)//si ya toco al jugador que no se desplace mas
        {
            desplazamiento = distancia;
        }
        transform.position = transform.position + desplazamiento;

        if (desplazamiento.sqrMagnitude < 0.0001) {

            llendo = !llendo; //para que vuelva al otro lado 
        }

    }
}
