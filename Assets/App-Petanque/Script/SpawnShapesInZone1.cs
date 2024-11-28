using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShapesInZone : MonoBehaviour
{
    // Liste des objets à spawn
    public GameObject[] shapes;

    // Nombre de formes à spawn
    public int numberOfShapes = 10;

    // Collider de la zone
    private Collider spawnZone;

    void Start()
    {
        // Récupérer le collider de la zone de spawn
        spawnZone = GetComponent<Collider>();

        // Spawn les formes
        SpawnShapes();
    }

    void SpawnShapes()
    {
        for (int i = 0; i < numberOfShapes; i++)
        {
            // Choisir un prefab aléatoire
            GameObject shapeToSpawn = shapes[Random.Range(0, shapes.Length)];

            // Générer une position aléatoire dans la zone
            Vector3 spawnPosition = GetRandomPositionInZone();

            // Instancier la forme
            Instantiate(shapeToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomPositionInZone()
    {
        // Calculer une position aléatoire à l'intérieur du collider
        Vector3 randomPosition = new Vector3(
            Random.Range(spawnZone.bounds.min.x, spawnZone.bounds.max.x),
            Random.Range(spawnZone.bounds.min.y, spawnZone.bounds.max.y),
            Random.Range(spawnZone.bounds.min.z, spawnZone.bounds.max.z)
        );

        return randomPosition;
    }

    private void OnDrawGizmos()
    {
        // Optionnel : Dessiner la zone de spawn dans l'éditeur
        if (spawnZone != null)
        {
            Gizmos.color = new Color(0, 1, 0, 0.3f);
            Gizmos.DrawCube(spawnZone.bounds.center, spawnZone.bounds.size);
        }
    }
}

