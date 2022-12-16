using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float speed = 0;         // speed al ser pública será accesible desde el Windows Inspector para poder ser también
                                    // modificada o ajustada desde allí

    private Rigidbody rb;           // Creamos una variable que nos permita acceder al Rigidbody de nuestro Player Objeto
                                    // para poder aplicarle fuerzas/movimientos

    private int count;

    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();         // Cargamos en rb el Rigidbody de nuestro Player Object
        count = 0;
    }

    void OnMove(InputValue movementValue)       // OnMove recoge cualquier evento de movimiento del objeto (y en este
                                                // caso se almacenará/registrará en el InputValue movementValue
                                                // InputValue es un tipo de dato binomial (2 valores o dimensiones)
                                                // por éso después utilizaremos un tipo Vector2 (movementVector)
                                                // para recoger el valor entregado por InputValue (objeto movementValue) 
                                                // en nuestra aplicación
    {
        Vector2 movementVector = movementValue.Get<Vector2>();     // Con movementValue.get<Vector2>() guardamos en un Vector2
                                                                   // los 2 datos recogidos por movementValue

        // Descomponemos el Vector2 en sus 2 componentes, para luego utilizarlas en la recomposición del Vector3 de AddForce
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()    // Esta función carga en un Vector3 los resultados del movimiento de nuestro Player Object al actuar sobre su Rigidbody
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);   //.AddForce necesita un Vector3, de ahí lo de la línea de código superior
                                         // y representa la fuerza aplicada, en este caso sobre nuestro Rigidbody
                                         // además, al multiplicarlo por speed podremos ampliar su velocidad
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
        }
        
    }

}
