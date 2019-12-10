using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCamara : MonoBehaviour
{

    public GameObject Jugador;

    private Vector3 distancia;

    void Start()
    {
        distancia = transform.position - Jugador.transform.position;
    }

    void LateUpdate()
    {
        transform.position = Jugador.transform.position + distancia;
    }
}
