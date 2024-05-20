using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadgenerator : MonoBehaviour
{
    public GameObject roadPrefab; // Le prefab du morceau de route à générer
    public Transform player; // La position du joueur pour déterminer quand générer de nouveaux morceaux de route
    public float generationDistance = 50f; // La distance à laquelle générer de nouveaux morceaux de route devant le joueur
    public float roadLength = 50f; // Longueur d'un morceau de route

    private float lastGeneratedPositionZ; // La dernière position Z où un morceau de route a été généré

    void Start()
    {
        // Initialiser lastGeneratedPositionZ avec la position initiale du dernier morceau de route
        lastGeneratedPositionZ = transform.position.z;
    }

    void Update()
    {
        // Générer un nouveau morceau de route si le joueur s'approche de la fin du dernier morceau généré
        if (player.position.z + generationDistance > lastGeneratedPositionZ)
        {
            GenerateRoad();
        }
    }

    void GenerateRoad()
    {
        // Calculer la nouvelle position Z pour le morceau de route
        float newRoadPositionZ = lastGeneratedPositionZ + roadLength;

        // Générer un nouveau morceau de route à la position calculée
        GameObject newRoad = Instantiate(roadPrefab, new Vector3(transform.position.x, transform.position.y, newRoadPositionZ), Quaternion.identity);

        // Mettre à jour la dernière position Z où un morceau de route a été généré
        lastGeneratedPositionZ = newRoadPositionZ;
    }
}
