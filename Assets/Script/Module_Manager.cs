using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module_Manager : MonoBehaviour
{
    public List<GameObject> modulePrefabs; // Lista de prefabs de módulos
    public Transform cameraTransform; // Referencia a la cámara
    public float spawnDistance = 50.0f; // Distancia entre módulos
    public int initialModules = 5; // Número inicial de módulos
    public int maxModules = 10; // Número máximo de módulos en escena
    private float nextSpawnZ = 0.0f; // Posición Z para el próximo módulo
    private Queue<GameObject> modules = new Queue<GameObject>();

    void Start()
    {
        // Instanciamos los primeros módulos para llenar el camino inicial
        for (int i = 0; i < initialModules; i++)
        {
            SpawnModule();
        }
    }

    void Update()
    {
        // Comprobamos si es necesario instanciar un nuevo módulo
        if (cameraTransform.position.z > nextSpawnZ - spawnDistance * initialModules)
        {
            SpawnModule();
        }

        // Eliminamos módulos que estén muy atrás
        if (modules.Count > maxModules)
        {
            Destroy(modules.Dequeue());
        }
    }

    void SpawnModule()
    {
        // Seleccionamos un prefab de módulo aleatorio
        GameObject modulePrefab = modulePrefabs[Random.Range(0, modulePrefabs.Count)];
        
        // Instanciamos un nuevo módulo
        GameObject newModule = Instantiate(modulePrefab, new Vector3(0, 0, nextSpawnZ), Quaternion.identity);
        modules.Enqueue(newModule);
        
        // Actualizamos la posición Z para el próximo módulo
        nextSpawnZ += spawnDistance;
    }
}

