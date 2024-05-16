using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module_Manager : MonoBehaviour
{
    public List<GameObject> modulePrefabs; // Lista de prefabs de m�dulos
    public Transform cameraTransform; // Referencia a la c�mara
    public float spawnDistance = 50.0f; // Distancia entre m�dulos
    public int initialModules = 5; // N�mero inicial de m�dulos
    public int maxModules = 10; // N�mero m�ximo de m�dulos en escena
    private float nextSpawnZ = 0.0f; // Posici�n Z para el pr�ximo m�dulo
    private Queue<GameObject> modules = new Queue<GameObject>();

    void Start()
    {
        // Instanciamos los primeros m�dulos para llenar el camino inicial
        for (int i = 0; i < initialModules; i++)
        {
            SpawnModule();
        }
    }

    void Update()
    {
        // Comprobamos si es necesario instanciar un nuevo m�dulo
        if (cameraTransform.position.z > nextSpawnZ - spawnDistance * initialModules)
        {
            SpawnModule();
        }

        // Eliminamos m�dulos que est�n muy atr�s
        if (modules.Count > maxModules)
        {
            Destroy(modules.Dequeue());
        }
    }

    void SpawnModule()
    {
        // Seleccionamos un prefab de m�dulo aleatorio
        GameObject modulePrefab = modulePrefabs[Random.Range(0, modulePrefabs.Count)];
        
        // Instanciamos un nuevo m�dulo
        GameObject newModule = Instantiate(modulePrefab, new Vector3(0, 0, nextSpawnZ), Quaternion.identity);
        modules.Enqueue(newModule);
        
        // Actualizamos la posici�n Z para el pr�ximo m�dulo
        nextSpawnZ += spawnDistance;
    }
}

