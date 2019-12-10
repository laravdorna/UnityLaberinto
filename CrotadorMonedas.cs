using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrotadorMonedas : MonoBehaviour
    //contorlador que hace rotar sobre si mismo la moneda
{

    public float velocidad = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //hace que rote en el eje elejido (z por que el elemento esta rotado) rotate es un vector v*t es el desplazamiento
        transform.Rotate(0,0,velocidad * Time.deltaTime);
    }
}
