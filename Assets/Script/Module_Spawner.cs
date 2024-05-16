using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module_Spawner : MonoBehaviour
{
    public GameObject modulePrefab; // Prefab del módulo
    public Transform cameraTransform; // Referencia a la cámara
    public float spawnDistance = 50.0f; // Distancia entre módulos
    private float nextSpawnZ = 0.0f; // Posición Z para el próximo módulo

    void Start()
    {
        // Instanciamos los primeros módulos para llenar el camino inicial
        for (int i = 0; i < 5; i++)
        {
            SpawnModule();
        }
    }

    void Update()
    {
        // Comprobamos si es necesario instanciar un nuevo módulo
        if (cameraTransform.position.z > nextSpawnZ - spawnDistance * 5)
        {
            SpawnModule();
        }
    }

    void SpawnModule()
    {
        // Instanciamos un nuevo módulo
        Instantiate(modulePrefab, new Vector3(0, 0, nextSpawnZ), Quaternion.identity);
        // Actualizamos la posición Z para el próximo módulo
        nextSpawnZ += spawnDistance;
    }
}
