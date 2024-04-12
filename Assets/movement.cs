using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float velocidadRotacion = 100f;

    private Animator animator; // Referencia al componente Animator

    void Start()
    {
        animator = GetComponent<Animator>(); // Obtener la referencia al componente Animator
    }

    void Update()
    {
        // Obtener la entrada del teclado
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcular la direcci�n de movimiento
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical).normalized;

        // Rotar el modelo del personaje en la direcci�n de movimiento
        if (movimiento != Vector3.zero)
        {
            Quaternion rotacionDeseada = Quaternion.LookRotation(movimiento);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacionDeseada, velocidadRotacion * Time.deltaTime);
        }

        // Mover el personaje
        transform.Translate(movimiento * velocidadMovimiento * Time.deltaTime, Space.World);

        // Actualizar la animaci�n del personaje
        if (animator != null)
        {
            float velocidadAnimacion = movimiento.magnitude;
            animator.SetFloat("Velocidad", velocidadAnimacion); // Asignar la velocidad de animaci�n al par�metro "Velocidad" del Animator
        }
    }
}
