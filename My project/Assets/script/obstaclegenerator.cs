using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclegenerator : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Les différents prefabs d'obstacles
    public Transform player; // La position du joueur pour déterminer quand générer de nouveaux obstacles
    public float generationDistance = 100f; // La distance à laquelle générer de nouveaux obstacles devant le joueur
    public float obstacleSpacing = 20f; // L'espace entre les obstacles générés
    public float generationOffset = 10f; // Distance devant le joueur pour générer les obstacles
    public float roadWidth = 5f; // La largeur de la route en unités
    public float startGenerationDistance = 10f; // La distance à laquelle commencer la génération des obstacles par rapport au générateur de route

    private float lastGeneratedPositionZ; // La dernière position Z où un obstacle a été généré
    private GameObject lastObstacle; // Le dernier obstacle généré

    void Start()
    {
        // Initialiser lastGeneratedPositionZ avec la position initiale du dernier morceau de route
        lastGeneratedPositionZ = transform.position.z;
    }

    void Update()
    {
        // Vérifier si le joueur est suffisamment proche pour commencer la génération
        if (Vector3.Distance(player.position, transform.position) <= startGenerationDistance)
        {
            // Générer un nouvel obstacle si le joueur s'approche de la fin du dernier obstacle généré
            if (player.position.z + generationDistance > lastGeneratedPositionZ)
            {
                GenerateObstacle();
            }
        }
    }

    void GenerateObstacle()
    {
        // Choisir un prefab d'obstacle aléatoirement
        GameObject obstaclePrefab = GetRandomObstaclePrefab();

        // Calculer la nouvelle position Z pour l'obstacle
        float newObstaclePositionZ = lastGeneratedPositionZ + obstacleSpacing;

        // Générer l'obstacle à une position aléatoire dans la largeur de la route
        float roadHalfWidth = roadWidth / 2;
        Vector3 newPosition = new Vector3(
            Random.Range(-roadHalfWidth, roadHalfWidth), // Assurez-vous que l'obstacle reste dans les limites de la route
            player.position.y, // Assurez-vous que l'obstacle reste au niveau de la route
            player.position.z + generationOffset + generationDistance
        );

        // Instancier le nouvel obstacle
        GameObject newObstacle = Instantiate(obstaclePrefab, newPosition, Quaternion.identity);

        // Mettre à jour la dernière position Z où un obstacle a été généré et le dernier obstacle généré
        lastGeneratedPositionZ = newObstaclePositionZ;
        lastObstacle = newObstacle;
    }

    GameObject GetRandomObstaclePrefab()
    {
        // Choisir un prefab d'obstacle aléatoire, en s'assurant qu'il est différent du dernier obstacle généré
        GameObject obstaclePrefab;
        do
        {
            obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        } while (obstaclePrefab == lastObstacle);

        return obstaclePrefab;
    }
}

