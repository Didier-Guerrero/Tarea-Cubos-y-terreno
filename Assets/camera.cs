using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform objetivo; // Transform del personaje a seguir
    public float distancia = 5.0f; // Distancia de la c�mara al personaje
    public float altura = 2.0f; // Altura de la c�mara sobre el personaje
    public float sensibilidadMouse = 100.0f; // Sensibilidad del mouse para rotaci�n de la c�mara

    private float rotacionX = 0.0f; // Rotaci�n horizontal de la c�mara

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor en el centro de la pantalla
    }

    void Update()
    {
        // Rotaci�n horizontal de la c�mara controlada por el mouse
        rotacionX += Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;
        Quaternion rotacion = Quaternion.Euler(0.0f, rotacionX, 0.0f);

        // Posicionar la c�mara detr�s y sobre el personaje, luego rotarla seg�n la rotaci�n horizontal
        Vector3 direccion = new Vector3(0, 0, -distancia);
        Vector3 offset = new Vector3(0, altura, 0);
        transform.position = objetivo.position - rotacion * direccion + offset;
        transform.LookAt(objetivo.position + Vector3.up * altura); // Mantener la c�mara mirando hacia el personaje
    }
}
