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
        if (Input.GetMouseButtonDown(0)) // Detecta clic izquierdo del rat�n
        {
            ShootBall();
        }
    }

    void ShootBall()
    {
        // Obtener la posici�n del rat�n en el espacio de la pantalla
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Convertir la posici�n del rat�n a un rayo en el mundo 3D
        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);
        RaycastHit hit;

        // Crear una nueva pelota en el punto de disparo
        GameObject ball = Instantiate(ballPrefab, shootPoint.position, shootPoint.rotation);

        if (Physics.Raycast(ray, out hit))
        {
            // Calcular la direcci�n desde el punto de disparo hacia el punto de impacto del rayo
            Vector3 direction = (hit.point - shootPoint.position).normalized;
            // Aplicar fuerza a la pelota en la direcci�n calculada
            ball.GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.Impulse);
        }
        else
        {
            // Si el rayo no impacta nada, disparamos en la direcci�n hacia adelante de la c�mara
            ball.GetComponent<Rigidbody>().AddForce(ray.direction * shootForce, ForceMode.Impulse);
        }
    }
}
