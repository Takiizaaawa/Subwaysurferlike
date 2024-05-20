using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mooveorbe : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float horizontalSpeed = 2f;
    public float roadWidth = 5f;

    void Update()
    {
        // Avancer le joueur le long de l'axe z à la vitesse spécifiée
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Déplacement latéral
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 newPosition = transform.position + Vector3.right * horizontalInput * horizontalSpeed * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, -roadWidth / 2, roadWidth / 2);

        // Appliquer la nouvelle position uniquement si l'entrée utilisateur est présente
        if (horizontalInput != 0)
        {
            transform.position = newPosition;
        }
    }
}
