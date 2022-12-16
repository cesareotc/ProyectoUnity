using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public GameObject player;  // Creamos una variable que referencie en este script al Objeto GameObject

    private Vector3 offset;    // Y creamos tambi�n un Vector3 que represente el offset 
                               // (diferencia o distancia que habr� entre la c�mara el y GameObject)

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;  // El offset se calcula a partir de la pos�ci�n actual de la c�mara
                                                                  // transform.position, menos la posici�n del GameObject (player)
                                                                  // y se calcula en el Start() porque se entiende que no variar�
                                                                  // a lo largo del script (se calcula s�lo 1 vez)
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;  // Y para que la c�mara se vaya moviendo cada frame (por �so el script est� aqu�)
                                                                  // manteniendo siempre en todo momento la distancia u offset establecida antes, se
                                                                  // utilizar� esta expresi�n. Y lo de "Late" es porque este c�culo se har� despu�s
                                                                  // de que efectivamente el player haya cambiado de posici�n en el frame
    }
}
