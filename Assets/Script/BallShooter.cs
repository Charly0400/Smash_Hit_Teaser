using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public GameObject ballPrefab; // Prefab de la pelota
    public Transform shootPoint; // Punto desde donde se dispara la pelota
    public float shootForce = 10f; // Fuerza con la que se dispara la pelota

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta clic izquierdo del ratón
        {
            ShootBall();
        }
    }

    void ShootBall()
    {
        // Obtener la posición del ratón en el espacio de la pantalla
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Convertir la posición del ratón a un rayo en el mundo 3D
        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);
        RaycastHit hit;

        // Crear una nueva pelota en el punto de disparo
        GameObject ball = Instantiate(ballPrefab, shootPoint.position, shootPoint.rotation);

        if (Physics.Raycast(ray, out hit))
        {
            // Calcular la dirección desde el punto de disparo hacia el punto de impacto del rayo
            Vector3 direction = (hit.point - shootPoint.position).normalized;
            // Aplicar fuerza a la pelota en la dirección calculada
            ball.GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.Impulse);
        }
        else
        {
            // Si el rayo no impacta nada, disparamos en la dirección hacia adelante de la cámara
            ball.GetComponent<Rigidbody>().AddForce(ray.direction * shootForce, ForceMode.Impulse);
        }
    }
}
