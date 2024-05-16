using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module_Spawner : MonoBehaviour
{
    public GameObject modulePrefab; // Prefab del m�dulo
    public Transform cameraTransform; // Referencia a la c�mara
    public float spawnDistance = 50.0f; // Distancia entre m�dulos
    private float nextSpawnZ = 0.0f; // Posici�n Z para el pr�ximo m�dulo

    void Start()
    {
        // Instanciamos los primeros m�dulos para llenar el camino inicial
        for (int i = 0; i < 5; i++)
        {
            SpawnModule();
        }
    }

    void Update()
    {
        // Comprobamos si es necesario instanciar un nuevo m�dulo
        if (cameraTransform.position.z > nextSpawnZ - spawnDistance * 5)
        {
            SpawnModule();
        }
    }

    void SpawnModule()
    {
        // Instanciamos un nuevo m�dulo
        Instantiate(modulePrefab, new Vector3(0, 0, nextSpawnZ), Quaternion.identity);
        // Actualizamos la posici�n Z para el pr�ximo m�dulo
        nextSpawnZ += spawnDistance;
    }
}
