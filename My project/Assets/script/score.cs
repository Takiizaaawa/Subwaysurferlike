using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Importation du namespace TextMeshPro


public class score : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 

    private float startTime; // Temps écoulé depuis le début du jeu
    private float currentScore; // Score actuel

    void Start()
    {
        startTime = Time.time; // Enregistrer le temps de début du jeu
        currentScore = 0; // Initialiser le score à 0
    }

    void Update()
    {
        // Calculer le temps écoulé depuis le début du jeu
        float elapsedTime = Time.time - startTime;

        // Mettre à jour le score en fonction du temps écoulé
        currentScore = elapsedTime * 10; // Vous pouvez ajuster le facteur pour changer la vitesse à laquelle le score augmente

        // Afficher le score
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        // Mettre à jour le texte d'affichage du score
        scoreText.text = "Score: " + Mathf.RoundToInt(currentScore);
    }
}
