using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform objetivo; // Transform del personaje a seguir
    public float distancia = 5.0f; // Distancia de la cámara al personaje
    public float altura = 2.0f; // Altura de la cámara sobre el personaje
    public float sensibilidadMouse = 100.0f; // Sensibilidad del mouse para rotación de la cámara

    private float rotacionX = 0.0f; // Rotación horizontal de la cámara

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor en el centro de la pantalla
    }

    void Update()
    {
        // Rotación horizontal de la cámara controlada por el mouse
        rotacionX += Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;
        Quaternion rotacion = Quaternion.Euler(0.0f, rotacionX, 0.0f);

        // Posicionar la cámara detrás y sobre el personaje, luego rotarla según la rotación horizontal
        Vector3 direccion = new Vector3(0, 0, -distancia);
        Vector3 offset = new Vector3(0, altura, 0);
        transform.position = objetivo.position - rotacion * direccion + offset;
        transform.LookAt(objetivo.position + Vector3.up * altura); // Mantener la cámara mirando hacia el personaje
    }
}
