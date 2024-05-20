using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Déplacer la caméra le long de l'axe z à la vitesse spécifiée
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

}
