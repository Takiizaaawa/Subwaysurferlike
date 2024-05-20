using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public Transform respawnPoint; // Le point de réapparition initial
    public Transform mainCamera; // La caméra à ramener

    private Vector3 initialPosition;
    private Vector3 initialCameraPosition;

    void Start()
    {
        // Enregistrer la position initiale du personnage et de la caméra
        initialPosition = transform.position;
        initialCameraPosition = mainCamera.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Vérifier si le personnage entre en collision avec un obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Ramener le personnage et la caméra à leur position initiale
            transform.position = initialPosition;
            mainCamera.position = initialCameraPosition;

            // Optionnel : Si vous souhaitez également réinitialiser la vélocité du Rigidbody
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
