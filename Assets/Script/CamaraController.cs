using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public GameObject player;  // Creamos una variable que referencie en este script al Objeto GameObject

    private Vector3 offset;    // Y creamos también un Vector3 que represente el offset 
                               // (diferencia o distancia que habrá entre la cámara el y GameObject)

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;  // El offset se calcula a partir de la posíción actual de la cámara
                                                                  // transform.position, menos la posición del GameObject (player)
                                                                  // y se calcula en el Start() porque se entiende que no variará
                                                                  // a lo largo del script (se calcula sólo 1 vez)
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;  // Y para que la cámara se vaya moviendo cada frame (por éso el script está aquí)
                                                                  // manteniendo siempre en todo momento la distancia u offset establecida antes, se
                                                                  // utilizará esta expresión. Y lo de "Late" es porque este cáculo se hará después
                                                                  // de que efectivamente el player haya cambiado de posición en el frame
    }
}
